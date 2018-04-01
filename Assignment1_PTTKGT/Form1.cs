using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Timers;

namespace Assignment1_PTTKGT
{
    public partial class Form1 : Form
    {
        public const int MAX_EXAM_DAYS = 8;
        public const int MAX_TIME_SLOTS = 5;
        public const double GAMMA = 0.5;

        List<Course> lstCourse;
        List<Student> lstStudent;
        List<StudyCourse> lstStudyCourse;
        List<ExaminationRoom> lstExamRoom;
        System.Timers.Timer timer;

        public Form1()
        {
            AllocConsole(); // show the console window to test
            InitializeComponent();
            
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        private void btnImportListExamRoom_Click(object sender, EventArgs e)
        {           
            progressBar1.Value = 0;

            OpenFileDialog fopenListExamRoom = new OpenFileDialog();
            fopenListExamRoom.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            fopenListExamRoom.ShowDialog();

            if (fopenListExamRoom.FileName != "")
            {
                timer = new System.Timers.Timer();
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Start();
                timer.Elapsed += new ElapsedEventHandler(timer_Tick);

                lstCourseEnroll.Clear();
                // Open Excel file
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Open(fopenListExamRoom.FileName);
                try
                {
                    // Open sheet


                    Excel._Worksheet sheet = wb.Sheets[1];
                    Excel.Range range = sheet.UsedRange;
                    // Read data
                    int rows = range.Rows.Count;
                    int cols = range.Columns.Count;
                    // Read the first row to make columns in listview
                    List<string> lstColumnName = new List<string>();
                    for (int c = 1; c <= cols; c++)
                    {
                        string columnName = Convert.ToString(range.Cells[1, c].Value);
                        ColumnHeader col = new ColumnHeader();
                        col.Text = columnName;
                        col.Width = 120;
                        lstCourseEnroll.Columns.Add(col);
                        lstColumnName.Add(columnName);
                    }
                    // Import data

                    lstExamRoom = new List<ExaminationRoom>();

                    for (int i = 2; i <= rows; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        string id = null;
                        int capacity = 0;
                        string kind = null;
                        string note = null;

                        for (int j = 1; j <= cols; j++)
                        {
                            if (j == 1)
                            {

                                item.Text = Convert.ToString(range.Cells[i, j].Value);

                                //Console.WriteLine(item.Text);
                                id = item.Text;
                            }
                            else
                            {
                                string subItem = Convert.ToString(range.Cells[i, j].Value);
                                item.SubItems.Add(subItem);
                                if (j == lstColumnName.IndexOf("SucChua")+1) capacity = Convert.ToInt32(subItem);
                                if (j == lstColumnName.IndexOf("TinhChatPhong")+1) kind = subItem;
                                if (j == lstColumnName.IndexOf("Note")+1) note = subItem;
                            }
                        }

                        ExaminationRoom room = new ExaminationRoom(id, capacity, kind, note);
                        lstExamRoom.Add(room);


                        lstCourseEnroll.Items.Add(item);
                        //Console.WriteLine(item.Text);

                    }

                    for (int k = 0; k < lstExamRoom.Count; k++)
                    {
                        ExaminationRoom test = lstExamRoom.ElementAt(k);
                        Console.WriteLine(test.Id + " " + test.Capacity + " " + test.Kind + " " + test.Note);
                    }

                    //MessageBox.Show(message1);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            }
            progressBar1.Value = progressBar1.Maximum;
            timer.Stop();
        }

        private void btnLstCourseEnroll_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            OpenFileDialog fopenListCourseEnroll = new OpenFileDialog();
            fopenListCourseEnroll.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            fopenListCourseEnroll.ShowDialog();

            if (fopenListCourseEnroll.FileName != "")
            {
                timer = new System.Timers.Timer();
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Start();
                timer.Elapsed += new ElapsedEventHandler(timer_Tick);
                
                // Open Excel file
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Open(fopenListCourseEnroll.FileName);
                try
                {
                    // Open sheet
                    Excel._Worksheet sheet = wb.Sheets[1];
                    Excel.Range range = sheet.UsedRange;
                    // Read data
                    int rows = range.Rows.Count;
                    int cols = range.Columns.Count;
                    // Read the first row to make columns in listview
                    List<string> lstColumnName = new List<string>();
                    for (int c = 1; c <= cols; c++)
                    {
                        string columnName = Convert.ToString(range.Cells[1, c].Value);
                        ColumnHeader col = new ColumnHeader();
                        col.Text = columnName;
                        col.Width = 120;
                        lstCourseEnroll.Columns.Add(col);
                        lstColumnName.Add(columnName);
                    }
                    // Import data

                    lstCourse = new List<Course>();
                    lstStudent = new List<Student>();
                    lstStudyCourse = new List<StudyCourse>();
     
                    for (int i = 2; i <= rows; i++)
                    {
                        //ListViewItem item = new ListViewItem();
                        string courseId = null;
                        string courseName = null;
                        string group = null;
                        string team = null;
                        string classId = null;
                        string studentId = null;
                        string lastMiddleName = null;
                        string firstName = null;
                        string email = null;
                        for (int j = 1; j <= cols; j++)
                        {
                            if (j == 1)
                            {

                                //item.Text = Convert.ToString(range.Cells[i, j].Value);
                                Text = Convert.ToString(range.Cells[i, j].Value);
                                //Console.WriteLine(item.Text);
                                courseId = Text;
                                continue;
                            }
                            else
                            {
                                string subItem = Convert.ToString(range.Cells[i, j].Value);
                                //item.SubItems.Add(subItem);
                                if (j == 2) courseName = subItem;
                                else if (j == 3) group = subItem;
                                else if (j == 4) team = subItem;
                                else if (j == 5) classId = subItem;
                                else if (j == 6) studentId = subItem;
                                else if (j == 7) lastMiddleName = subItem;
                                else if (j == 8) firstName = subItem;
                                else if (j == 9) email = subItem;
                                
                            }
                        }
                        Course courseItem = new Course(courseId, courseName);
                        Group groupItem = new Group(group, team);

                        if (checkContainsCourse(courseId, groupItem, studentId) == false) 
                        {
                            courseItem.EnrolledStudent.Add(studentId);
                            lstCourse.Add(courseItem);
                        }

                        StudyCourse StudyCourseItem = new StudyCourse(studentId, courseId, group, team);
                        lstStudyCourse.Add(StudyCourseItem);

                        Student studentItem = new Student(studentId, classId, lastMiddleName, firstName, email);

                        if (checkContainsStudent(studentId) == false)
                        {
                            lstStudent.Add(studentItem);
                        }





                        //lstCourseEnroll.Items.Add(item);
                        //Console.WriteLine(item.Text);
                        
                    }
                    

                    // Print list Student
                    //for (int k = 0; k < lstStudent.Count; k++)
                    //{
                    //    Student test = lstStudent.ElementAt(k);
                    //    Console.WriteLine(test.Id + " " + test.ClassId + " " + test.LastMiddleName + " " + test.FirstName + " " + test.Email);
                    //}

                    buildWeightMatrix();

                    // Print list Course
                    for (int k = 0; k < lstCourse.Count; k++)
                    {
                        Course test = lstCourse.ElementAt(k);
                        Console.WriteLine(test.Id + " " + test.Name + " " + test.Degree + " " + test.MaxWeight);

                        for (int l = 0; l < test.orderListAdjacentCourse().Count; l++)
                            Console.WriteLine(test.orderListAdjacentCourse().ElementAt(l).Id);
                        //for (int l = 0; l < test.EnrolledStudent.Count; l++)
                        //    Console.WriteLine(test.EnrolledStudent.ElementAt(l));
                    }

                    /*
                    // Print list StudyCourse
                    for (int k = 0; k < lstStudyCourse.Count; k++)
                    {
                        StudyCourse test = lstStudyCourse.ElementAt(k);
                        Console.WriteLine(test.StudentId + " " + test.CourseId + " " + test.Group + " " + test.Team);
                    }
                     */

                    //MessageBox.Show(message1);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            }
            progressBar1.Value = progressBar1.Maximum;
            timer.Stop();
           
        }

        private bool checkContainsCourse(string courseId, Group group, string studentId) 
        {
            bool checkContains = false;
            for (int k = 0; k < lstCourse.Count; k++)
            {
                Course test = lstCourse.ElementAt(k);
                if (courseId == test.Id)
                {
                    checkContains = true;
                    test.EnrolledStudent.Add(studentId);
                    if (!test.checkContainsGroup(group))
                    {
                        test.ListGroup.Add(group);
                    }
                    break;
                }
            }
            return checkContains;
        }

        private bool checkContainsStudent(string studentId)
        {
            bool checkContains = false;
            for (int k = 0; k < lstStudent.Count; k++)
            {
                Student test = lstStudent.ElementAt(k);
                if (studentId == test.Id)
                {
                    checkContains = true;
                    break;
                }
            }
            return checkContains;
        }

        private int commonStudents(Course course1, Course course2) 
        {
            return course1.EnrolledStudent.Intersect(course2.EnrolledStudent).ToList().Count;
        }

        private int[,] buildWeightMatrix()
        {
            
            int len = lstCourse.Count;
            int[,] weightMatrix = new int[len, len];
            string text = "";
            // assign weights to matrix
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    weightMatrix[i, j] = commonStudents(lstCourse.ElementAt(i), lstCourse.ElementAt(j));
                    weightMatrix[j, i] = weightMatrix[i, j];
                }
            }
           
            // Set degree, maxWeight and listAdjacentCourse
            for (int i = 0; i < len; i++)
            {
                int max = 0;
                int degree = 0;
                for (int j = 0; j < len; j++)
                {
                    if (weightMatrix[i, j] > 0)
                        degree += 1;
                    if (weightMatrix[i, j] > max)
                        max = weightMatrix[i, j];
                        
                }
                lstCourse.ElementAt(i).Degree = degree;
                lstCourse.ElementAt(i).MaxWeight = max;
            }

            for (int i = 0; i < len - 1; i++)
            {
                
                for (int j = i + 1; j < len; j++)
                {
                    if (weightMatrix[i, j] > 0)
                    {
                        lstCourse.ElementAt(i).ListAdjacentCourse.Add(lstCourse.ElementAt(j));
                        lstCourse.ElementAt(j).ListAdjacentCourse.Add(lstCourse.ElementAt(i));
                    }
                }
                
            }

            // Write weightMatrix to a file
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    text += (weightMatrix[i, j] + " ");
                }
                text += "\n";
            }

            System.IO.File.WriteAllText(@"D:\\fileA.txt", text);

            return weightMatrix;
        }

        private Color[,] colorMatrix()
        {
            Color[,] colorMatrix = new Color[MAX_EXAM_DAYS, MAX_TIME_SLOTS];

            for (int day = 1; day <= MAX_EXAM_DAYS; day++)
            {
                for (int slot = 1; slot <= MAX_TIME_SLOTS; slot++)
                {
                    Color colorItem = new Color(day, slot);
                    colorMatrix[day, slot] = colorItem;
                }
            }

            return colorMatrix;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog fsave = new SaveFileDialog();
            fsave.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            fsave.ShowDialog();

            if (fsave.FileName != "")
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                Excel._Worksheet sheet = null;
                try
                {
                    sheet = wb.ActiveSheet;
                    sheet.Name = "Exam schedule";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, lstCourseEnroll.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Lịch thi";

                    // Create contents
                    for (int i = 1; i <= lstCourseEnroll.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = lstCourseEnroll.Columns[i - 1].Text;

                    }

                    // Export data
                    for (int i = 1; i <= lstCourseEnroll.Items.Count; i++)
                    {
                        ListViewItem item = lstCourseEnroll.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= lstCourseEnroll.Columns.Count; j++)
                        {
                            sheet.Cells[i + 2, j] = item.SubItems[j - 1].Text;
                            sheet.Cells[i + 2, j].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        }
                    }
                    wb.SaveAs(fsave.FileName);
                    MessageBox.Show("Saved","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            }
            else
            {
                MessageBox.Show("You did not select any files", "Message", MessageBoxButtons.OK);
            }
        }

        private void initializeExamRooms(Color[,] colorMatrix)
        {
            Color color;
            for (int i = 0; i < MAX_EXAM_DAYS; i++)
            {
                for (int j = 0; j < MAX_TIME_SLOTS; j++)
                {
                    color = colorMatrix[i, j];
                    for (int k = 0; k < lstExamRoom.Count(); k++)
                    {
                        lstExamRoom.ElementAt(k).Color = color;
                        color.ListRoom.Add(lstExamRoom.ElementAt(k));
                    }
                }
            }
        }

        private int distance1(Color color1, Color color2)
        {
            if (color1.Day == color2.Day)
                return System.Math.Abs(color1.Slot - color2.Slot);
            else return -1;
        }

        private int distance2(Color color1, Color color2)
        {
            return (color1.Day - color2.Day);
        }

        private bool distance3(Color color1, Color color2)
        {
            int n1 = (color1.Day) * MAX_TIME_SLOTS + color1.Slot;
            int n2 = (color2.Day) * MAX_TIME_SLOTS + color2.Slot;

            if (System.Math.Abs(n1 - n2) < 4)
                return false;

            return true;
        }

        private double totalDis(Color color1, Color color2)
        {
            return distance1(color1, color2) + GAMMA * distance2(color1, color2);
        }

        private int binarySearch(List<ExaminationRoom> sortedList, int numOfStudents)
        {
            int start = 0;
            int end = sortedList.Count() - 1;
            bool found = false;
            int mid = -1;

            while (start <= end && found == false)
            {
                mid = (start + end) / 2;
                if (sortedList.ElementAt(mid).Capacity == numOfStudents)
                {
                    found = true;
                    end = mid - 1;
                }
                else
                {
                    if (numOfStudents < sortedList.ElementAt(mid).Capacity)
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }
            return end + 1;
        }

        private int indexOfRoom(string roomID, List<ExaminationRoom> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i).Id == roomID)
                    return i;
            }
            return -1;
        }

        private List<ExaminationRoom> getRoom(int numOfStudents, List<ExaminationRoom> sortedList)
        {
            List<ExaminationRoom> listSelectedRooms = new List<ExaminationRoom>();
            while (numOfStudents > 0)
            {
                int i = binarySearch(sortedList, numOfStudents);
                if (i < 0)
                {
                    i = 0;
                }
                else if (i >= sortedList.Count())
                {
                    i = sortedList.Count() - 1;
                }
                if (i < 0)
                {
                    listSelectedRooms = new List<ExaminationRoom>();
                    break;
                }
                numOfStudents -= sortedList.ElementAt(i).Capacity;
                ExaminationRoom selectedRoom = sortedList.ElementAt(i);
                string selectedRoomID = selectedRoom.Id;

                sortedList.RemoveAt(i);

                listSelectedRooms.Add(selectedRoom);

                for (int j = 0; j < sortedList.Count; j++)
                {
                    if (sortedList.ElementAt(j).Id == selectedRoomID)
                    {
                        sortedList.RemoveAt(j);
                        break;
                    }
                }
            }
            return listSelectedRooms;
        }

        private List<ExaminationRoom> selectRoom(int numOfStudents, Color color)
        {
            if (numOfStudents > color.availableCapacity())
            {
                return new List<ExaminationRoom>();
            }

            List<ExaminationRoom> listRoom = color.getAvailableRooms();


            List<ExaminationRoom> sortedList = color.ListRoom.OrderBy(x => x.Capacity).ToList();
            return getRoom(numOfStudents, sortedList);
        }





        // This function is for represent the progress bar
        private void timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != progressBar1.Maximum)
                progressBar1.Value++;
        }

    }
}
