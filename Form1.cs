using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileVerify
{
    public partial class Form1 : Form
    {
        private int hashedFileCount = 0;
        private int hashedFileCount2 = 0;
        private TaskCompletionSource<int> hashedFileCountTaskCompletionSource;

        public Form1()
        {
            InitializeComponent();
            hashedFileCountTaskCompletionSource = new TaskCompletionSource<int>();
        }

        private void btnLoadDirectory1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    lblDirectory1.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnLoadDirectory2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    lblDirectory2.Text = fbd.SelectedPath;
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            hashedFileCount = 0; // Reset the counter before hashing
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listView1.Items.Clear();
            hashedFileCount2 = 0;
            List<string> fileNames = new List<string>();
            bool hashMismatches = false;
            var files1 = Directory.GetFiles(lblDirectory1.Text, "*", SearchOption.AllDirectories)
                .OrderBy(p => p)
                .ToArray();

            var files2 = Directory.GetFiles(lblDirectory2.Text, "*", SearchOption.AllDirectories)
                .OrderBy(p => p)
                .ToArray();

            foreach (string file in files1)
            {
                listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(file.Replace(lblDirectory1.Text, "")))); // Invoke UI update
                fileNames.Add(file.Replace(lblDirectory1.Text, "").Replace("\\\\", "\\"));
            }

            foreach (string file in files2)
            {
                listBox2.Invoke((MethodInvoker)(() => listBox2.Items.Add(file.Replace(lblDirectory2.Text, "")))); // Invoke UI update
                fileNames.Add(file.Replace(lblDirectory2.Text, "").Replace("\\\\","\\"));
            }
            fileNames = fileNames.Distinct().ToList();
            label3.Invoke((MethodInvoker)(() => label3.Text = Convert.ToString(listBox1.Items.Count))); // Invoke UI update
            label4.Invoke((MethodInvoker)(() => label4.Text = Convert.ToString(listBox2.Items.Count))); // Invoke UI update

           // return;
            
            
            int ix = 0;

            object lockObject = new object(); // Synchronization object
            var enumerableCollection = fileNames.Select(tuple => (tuple));

            await Task.Run(() =>
            {
                Parallel.ForEach(enumerableCollection, tuple =>
                {
                    ListViewItem lvi = new ListViewItem(tuple);
                    Console.WriteLine(Path.Combine(lblDirectory1.Text, tuple));
                    //string dir = Path.Combine(lblDirectory1.Text, tuple);
                    if (File.Exists(Path.Combine(lblDirectory1.Text, tuple.Substring(1))))
                    {
                        lvi.SubItems.Add("1");
                    }
                    else
                    {
                        lvi.SubItems.Add("0");
                    }
                    if (File.Exists(Path.Combine(lblDirectory2.Text, tuple.Substring(1))))
                    {
                        lvi.SubItems.Add("1");
                    }
                    else
                    {
                        lvi.SubItems.Add("0");
                    }

                    using (var sha256 = SHA256.Create())
                    {
                        byte[] file1Hash = null;
                        byte[] file2Hash = null;

                        if (File.Exists(Path.Combine(lblDirectory1.Text, tuple.Substring(1))))
                        {
                            using (var stream = File.OpenRead(Path.Combine(lblDirectory1.Text, tuple.Substring(1))))
                            {
                                file1Hash = sha256.ComputeHash(stream);
                            }
                        }

                        if (File.Exists(Path.Combine(lblDirectory2.Text, tuple.Substring(1))))
                        {
                            using (var stream = File.OpenRead(Path.Combine(lblDirectory2.Text, tuple.Substring(1))))
                            {
                                file2Hash = sha256.ComputeHash(stream);
                            }
                        }
                        if (File.Exists(Path.Combine(lblDirectory1.Text, tuple.Substring(1))) && File.Exists(Path.Combine(lblDirectory2.Text, tuple.Substring(1))))
                        {
                            if (AreHashesEqual(file1Hash, file2Hash))
                            {
                                lvi.SubItems.Add("1");
                            }
                            else
                            {
                                hashMismatches = true;
                                lvi.SubItems.Add("0");
                            }
                            Interlocked.Increment(ref hashedFileCount2); // Increment the counter
                        }
                        else
                        {
                            lvi.SubItems.Add("null");
                        }
                       

                        listView1.Invoke((MethodInvoker)(() => listView1.Items.Add(lvi))); // Invoke UI update

                        ix += 1;
                        Console.WriteLine(ix + " hashes calculated.");
                        UpdateHashedFileCountLabel2(hashedFileCount2);
                    }
                });
            });

            label1.Invoke((MethodInvoker)(() => label1.Text = listView1.Items.Count.ToString())); // Invoke UI update

            if (listBox1.Items.Count != listBox2.Items.Count)
            {
                MessageBox.Show("Counts mismatch.");
                
            }
            else
            {
                MessageBox.Show("Counts match.");
            }
            if (hashMismatches)
            {
                MessageBox.Show("Hashes mismatch.");

            }
            else
            {
                MessageBox.Show("Hashes match.");
            }
            List<string> differences = GetDifferences(listBox1, listBox2);

            if (differences.Count != 0)
            {
                foreach (string difference in differences)
                {
                    MessageBox.Show("Filenames mismatches." + Environment.NewLine + difference);
                    
                }
            }
            else
            {
                MessageBox.Show("Filenames match.");
            }

     


        
        }


        private List<string> GetDifferences(ListBox lstbox1, ListBox lstbox2)
        {
            List<string> differences = new List<string>();
            List<string> itemsList1 = new List<string>();
            List<string> itemsList2 = new List<string>();

            foreach (string x in lstbox1.Items.Cast<string>().ToList())
            {
                itemsList1.Add(new FileInfo(x).Name);
            }

            foreach (string x in lstbox2.Items.Cast<string>().ToList())
            {
                itemsList2.Add(new FileInfo(x).Name);
            }

            // Find items in list1 that are not in list2
            var missingInList2 = itemsList1.Except(itemsList2);
            differences.AddRange(missingInList2);

            // Find items in list2 that are not in list1
            var missingInList1 = itemsList2.Except(itemsList1);
            differences.AddRange(missingInList1);

            return differences;
        }



        private static bool AreHashesEqual(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length)
            {
                return false; // Hashes have different lengths, they are not equal
            }

            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                {
                    return false; // Found a difference in hash values, they are not equal
                }
            }

            return true; // No differences found, hashes are equal
        }



        private void UpdateHashedFileCountLabel2(int count)
        {
            if (lblCalculatedHashes.InvokeRequired)
            {
                lblCalculatedHashes.Invoke((MethodInvoker)delegate
                {
                    lblCalculatedHashes.Text = count.ToString() + " hashes calculated.";
                });
            }
            else
            {
                lblCalculatedHashes.Text = count.ToString() + " hashes calculated.";
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
 
        }
    }
}
