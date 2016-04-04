/*
 * Siyang Li 11443579
 * threading HW CptS322
 * 
 * Key idea, making threads under allsorting thread. So all while loops or Join() would not let the
 *      UI thread freeze
 * 
 * 
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;


namespace cpts322hw12_threading
{
    public partial class Form1 : Form
    {
        WebClient wc = new WebClient();

        public delegate void delUpdateUITextBox(string text);

        ThreadStart threadstart_download;
        Thread thread_download; //thread_download = new Thread(the parallel function I call);

        string downloadedString = "";


        // sorting part1
        ThreadStart allEightThreadStart;// this is for single-threaded sorting
        Thread allEightThread;
        Stopwatch swsingle = new Stopwatch();// this StopWatch is for single-threaded sorting

        //part2

        List<Thread> tl = new List<Thread>(); // this is for multi-threaded sorting, going to add 8 thread to the list
        private static Counter counter = new Counter();
        Stopwatch swmulti = new Stopwatch();

        Random rand = new Random();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void download_Click(object sender, EventArgs e)
        {
            if (urltextbox.Text != "")
            {
                // disable the button while task downloading is executing
                urltextbox.Enabled = false;
                download.Enabled = false;

                threadstart_download = new ThreadStart(doDownload);
                thread_download = new Thread(threadstart_download);
                thread_download.Start();
            }

        }
        public void doDownload()
        {   

            delUpdateUITextBox delUpdateUITextBox1 = new delUpdateUITextBox(UpdateUITextBox);

            Uri stringurl = new Uri(urltextbox.Text);
            downloadedString = wc.DownloadString(stringurl);

            // invoke , call the UI thread method
            this.downloadresultbox.BeginInvoke(delUpdateUITextBox1, downloadedString);
        }

        public void UpdateUITextBox(string newText)
        {
            this.downloadresultbox.Text = newText;
            // enable download buttons and textbox after finished downloading
            urltextbox.Enabled = true;
            download.Enabled = true;
        }

        private void downloadresultbox_TextChanged(object sender, EventArgs e)
        {

        }

        // remember to add form close thread abort
        ////////////////////////        sorting     ///////////////////////
        Thread AllSorting;
        private void button_sorting_Click(object sender, EventArgs e)
        {
            // samething, disable the button while executing
            button_sorting.Enabled = false;

            // this is the general thread that would do both single and multi threaded sorting
            // I have single and multi (total 2) threads initialize in this thread
            // and there would be more threads below...
            AllSorting = new Thread(new ThreadStart(doAllSorting));
            AllSorting.Start();

            
        }

        public void doAllSorting()
        {
            counter.Count++;
            Thread singlethread = new Thread(new ThreadStart(Sorting_SingleThread));
            singlethread.Start();

            //singlethread.Join();  // how to use join? here i use counter.Count to make sure single thread finished.
            //idea is: before starting single-threaded sorting, count+1.
            // at the moment it finish and get the result textbox updated, count-1
            // so this line of code just keep track of counter.Count, see when it reaches 0. it represents single thread completed.
            while (true) { if (counter.Count == 0) break; }


            Thread multithread = new Thread(new ThreadStart(Sorting_MultiThread));
            multithread.Start();
            //Sorting_MultiThread();

        }


        public void Sorting_SingleThread()
        {
            allEightThreadStart = new ThreadStart(doSingleThread);
            allEightThread = new Thread(allEightThreadStart);
            allEightThread.Start();
        }
        public void doSingleThread()
        {
            delUpdateUITextBox delUpdateUITextBox2 = new delUpdateUITextBox(UpdateSortingTextBox2);
            List<int> nums = new List<int>();
            swsingle.Start();
            for(int i = 0; i < 8; i++)
            {
                nums = fillList(); // filllist always generate a new random list and return to the list
                nums.Sort();// make another thread only for this. 1 thread for ALL sorting
            }
            swsingle.Stop();
            TimeSpan ts = swsingle.Elapsed;
            string timeString = Convert.ToInt32(ts.TotalMilliseconds).ToString();
            swsingle.Reset(); // reset the timer

            // invoke call, update result textbox
            this.textBox_sortingresult.BeginInvoke(delUpdateUITextBox2, timeString);
            counter.Count--;// ==0.  Count - 1 to indicate this part is done, move on to multi-thread sorting
        }

        public void Sorting_MultiThread()
        {

            delUpdateUITextBox delUpdateUITextBox3 = new delUpdateUITextBox(UpdateSortingTextBox3);
            for (int i = 0; i < 8; i++)// fill in the thread list with 8 threads
            {
                ThreadStart tstart = new ThreadStart(doMultiThread);
                Thread t = new Thread(tstart);
                tl.Add(t); //tl stands for thread list, which initialized on top/
            }
            swmulti.Start();
            foreach (Thread t in tl) // start all threads in thread list
            {
                counter.Count++;
                t.Start();
            }
            // same idea, use Count to keep track of the process 
            while (true) { if (counter.Count == 0) break; }
            swmulti.Stop();
            TimeSpan ts = swmulti.Elapsed;
            string timeString = Convert.ToInt32(ts.TotalMilliseconds).ToString();
            swmulti.Reset();
            this.textBox_sortingresult.BeginInvoke(delUpdateUITextBox3, timeString);
            //textBox_sortingresult.Text += "multi thread time: " + timeString + "ms.\r\n";

            tl.Clear(); // remember to clear thread list. 
        }

        public void doMultiThread()
        {
            // for each thread, generate random numbers and sort it.
            List<int> nums = new List<int>();
            nums = fillList();
            nums.Sort();
            counter.Count--;
        }




        public void UpdateSortingTextBox2(string newText)//for part1, update result of single-threaded sorting
        {
            this.textBox_sortingresult.Text += "Single-thread time: " + newText + "ms.\r\n"; // \r\n go to next line of textbox
        }
        public void UpdateSortingTextBox3(string newText)//for part2, update result of multi-threaded sorting
        {
            this.textBox_sortingresult.Text += "Multi-thread time: " + newText + "ms.\r\n"; // \r\n go to next line of textbox
            button_sorting.Enabled = true;
        }


        // the counter class is made due to the idea of keep tracking if all threads are completed
        public class Counter
        {
            private int count;
            public int Count
            {
                get
                {
                    return count;
                }
                set
                {
                    count = value;
                }
            }
            public Counter() { this.count = 0; }// default counter.Count == 0;
        }

        // this is the fill list method that generate and return to a int list (with 1000000 int in it)
        private List<int> fillList()
        {
            List<int> l1 = new List<int>();
            int num = 0;
            for (int i = 0; i < 1000000; i++)
            {
                num = rand.Next(101);
                l1.Add(num);
            }
            return l1;
        }
    }
}
