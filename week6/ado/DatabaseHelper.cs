using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace ado
{
    public class DatabaseHelper
    {
        private string connectionString = "server=localhost;database=network;uid=root;pwd=123456;";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        private int GetSchoolIdByName(string schoolName, MySqlConnection conn)
        {
            int schoolId = -1;
            using (MySqlCommand cmd = new MySqlCommand("SELECT SchoolID FROM School WHERE SchoolName = @SchoolName", conn))
            {
                cmd.Parameters.AddWithValue("@SchoolName", schoolName);
                LogOperation(cmd.CommandText);
                schoolId = (int)cmd.ExecuteScalar();
            }
            return schoolId;
        }
        private int GetClassIdByName(string schoolName, string className, MySqlConnection conn)
        {
            int classId = -1;
            using (MySqlCommand cmd = new MySqlCommand("SELECT ClassID FROM Class WHERE SchoolID = (SELECT SchoolID FROM School WHERE SchoolName = @SchoolName) AND ClassName = @ClassName", conn))
            {
                cmd.Parameters.AddWithValue("@SchoolName", schoolName);
                cmd.Parameters.AddWithValue("@ClassName", className);
                LogOperation(cmd.CommandText);
                classId = (int)cmd.ExecuteScalar();
            }
            return classId;
        }
        private string GetClassNameById(int classId, MySqlConnection conn)
        {
            string className = "";
            using (MySqlCommand cmd = new MySqlCommand("SELECT ClassName FROM Class WHERE ClassID = @ClassID", conn))
            {
                cmd.Parameters.AddWithValue("@ClassID", classId);
                LogOperation(cmd.CommandText);
                className = (string)cmd.ExecuteScalar();
            }
            return className;
        }
        // 添加学校
        public int AddSchool(string schoolName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO School (SchoolName) VALUES (@SchoolName)", conn))
                {
                    cmd.Parameters.AddWithValue("@SchoolName", schoolName);
                    LogOperation(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand("SELECT @@IDENTITY", conn))
                {
                    return 1;
                }
            }
        }

        // 根据学校添加班级
        public int AddClass(string schoolName, string className)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // 先获取学校ID
                int schoolId = GetSchoolIdByName(schoolName, conn);
                if (schoolId == -1)
                {
                    return -1;
                }
                // 添加班级
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Class (SchoolID, ClassName) VALUES (@SchoolID, @ClassName)", conn))
                {
                    cmd.Parameters.AddWithValue("@SchoolID", schoolId);
                    cmd.Parameters.AddWithValue("@ClassName", className);
                    LogOperation(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand("SELECT @@IDENTITY", conn))
                {
                    return 1;
                }
            }
        }

        // 根据学校班级添加学生
        public int AddStudent(string schoolName, string className, string studentName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // 先获取班级ID
                int classId = GetClassIdByName(schoolName, className, conn);
                if (classId == -1)
                {
                    return -1;
                }
                // 添加学生
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Student (ClassID, StudentName) VALUES (@ClassID, @StudentName)", conn))
                {
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@StudentName", studentName);
                    LogOperation(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
                // 返回新添加的学生ID
                using (MySqlCommand cmd = new MySqlCommand("SELECT @@IDENTITY", conn))
                {
                    return 1;
                }
            }
        }

        // 修改学生信息，只更新班级和学校
        public int UpdateStudent(int studentId, string newSchoolName, string newClassName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // 获取新班级ID
                int newClassId = GetClassIdByName(newSchoolName, newClassName, conn);
                if (newClassId == -1)
                {
                    return -1;
                }

                // 更新学生班级ID
                using (MySqlCommand cmd = new MySqlCommand("UPDATE Student SET ClassID = @ClassID WHERE StudentID = @StudentID", conn))
                {
                    cmd.Parameters.AddWithValue("@ClassID", newClassId);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    LogOperation(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
                return 1;
            }
        }

        // 删除学生
        public void DeleteStudent(int studentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Student WHERE StudentID = @StudentID", conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);

                    cmd.ExecuteNonQuery();
                    LogOperation(cmd.CommandText);
                }
            }
        }
        // 获取学校名列表
        public List<string> GetSchoolNameList()
        {
            List<string> schoolNames = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT SchoolName FROM School", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schoolNames.Add(reader["SchoolName"].ToString());
                        }
                    }
                    LogOperation(cmd.CommandText);
                }
            }
            return schoolNames;
        }
        // 根据学校名获取班级名列表
        public List<string> GetClassNameListBySchoolName(string schoolName)
        {
            List<string> classNames = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT ClassName FROM Class WHERE SchoolID = (SELECT SchoolID FROM School WHERE SchoolName = @SchoolName)", conn))
                {
                    cmd.Parameters.AddWithValue("@SchoolName", schoolName);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            classNames.Add(reader["ClassName"].ToString());
                        }
                    }
                    LogOperation(cmd.CommandText);
                }
            }
            return classNames;
        }
        // 获取所有学生名列表
        public List<string> GetAllStudentNames()
        {
            List<string> studentNames = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT StudentName FROM Student", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentNames.Add(reader["StudentName"].ToString());
                        }
                    }
                    LogOperation(cmd.CommandText);
                }
            }
            return studentNames;
        }
        // 获取包含学生ID、学生名、班级名、学校名的列表
        public List<StudentInfo> GetAllStudentsWithDetails()
        {
            List<StudentInfo> studentsDetails = new List<StudentInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(
                    @"SELECT s.StudentID, s.StudentName, c.ClassName, sc.SchoolName 
                  FROM Student s
                  INNER JOIN Class c ON s.ClassID = c.ClassID
                  INNER JOIN School sc ON c.SchoolID = sc.SchoolID", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsDetails.Add(new StudentInfo
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                StudentName = reader.GetString(reader.GetOrdinal("StudentName")),
                                ClassName = reader.GetString(reader.GetOrdinal("ClassName")),
                                SchoolName = reader.GetString(reader.GetOrdinal("SchoolName"))
                            });
                        }
                    }
                    LogOperation(cmd.CommandText);
                }
            }
            return studentsDetails;
        }
        // 根据学生名模糊查询学生信息
        public List<StudentInfo> SearchStudentsByName(string studentName)
        {
            List<StudentInfo> studentsDetails = new List<StudentInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT s.StudentID, s.StudentName, c.ClassName, sc.SchoolName " +
                                                       "FROM Student s " +
                                                       "INNER JOIN Class c ON s.ClassID = c.ClassID " +
                                                       "INNER JOIN School sc ON c.SchoolID = sc.SchoolID " +
                                                       "WHERE s.StudentName LIKE @StudentName", conn))
                {
                    cmd.Parameters.AddWithValue("@StudentName", $"%{studentName}%");
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsDetails.Add(new StudentInfo
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                StudentName = reader.GetString(reader.GetOrdinal("StudentName")),
                                ClassName = reader.GetString(reader.GetOrdinal("ClassName")),
                                SchoolName = reader.GetString(reader.GetOrdinal("SchoolName"))
                            });
                        }
                        LogOperation(cmd.CommandText);
                    }
                }
            }
            return studentsDetails;
        }
        // 根据学生ID精确查询学生信息
        public List<StudentInfo> SearchStudentsById(int studentId)
        {
            List<StudentInfo> studentsDetails = new List<StudentInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT s.StudentID, s.StudentName, c.ClassName, sc.SchoolName " +
                                                       "FROM Student s " +
                                                       "INNER JOIN Class c ON s.ClassID = c.ClassID " +
                                                       "INNER JOIN School sc ON c.SchoolID = sc.SchoolID " +
                                                       "WHERE s.StudentID = @StudentID", conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsDetails.Add(new StudentInfo
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                StudentName = reader.GetString(reader.GetOrdinal("StudentName")),
                                ClassName = reader.GetString(reader.GetOrdinal("ClassName")),
                                SchoolName = reader.GetString(reader.GetOrdinal("SchoolName"))
                            });
                        }
                    }
                    LogOperation(cmd.CommandText);
                }
            }
            return studentsDetails;
        }

        // 根据班级名精确查询学生信息
        public List<StudentInfo> SearchStudentsByClass(string className)
        {
            List<StudentInfo> studentsDetails = new List<StudentInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT s.StudentID, s.StudentName, c.ClassName, sc.SchoolName " +
                                                       "FROM Student s " +
                                                       "INNER JOIN Class c ON s.ClassID = c.ClassID " +
                                                       "INNER JOIN School sc ON c.SchoolID = sc.SchoolID " +
                                                       "WHERE c.ClassName = @ClassName", conn))
                {
                    cmd.Parameters.AddWithValue("@ClassName", className);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsDetails.Add(new StudentInfo
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                StudentName = reader.GetString(reader.GetOrdinal("StudentName")),
                                ClassName = reader.GetString(reader.GetOrdinal("ClassName")),
                                SchoolName = reader.GetString(reader.GetOrdinal("SchoolName"))
                            });
                        }
                    }
                    LogOperation(cmd.CommandText);
                }
            }
            return studentsDetails;
        }

        // 根据学校名模糊查询学生信息
        public List<StudentInfo> SearchStudentsBySchool(string schoolName)
        {
            List<StudentInfo> studentsDetails = new List<StudentInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT s.StudentID, s.StudentName, c.ClassName, sc.SchoolName " +
                                                       "FROM Student s " +
                                                       "INNER JOIN Class c ON s.ClassID = c.ClassID " +
                                                       "INNER JOIN School sc ON c.SchoolID = sc.SchoolID " +
                                                       "WHERE sc.SchoolName LIKE @SchoolName", conn))
                {
                    cmd.Parameters.AddWithValue("@SchoolName", $"%{schoolName}%");
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsDetails.Add(new StudentInfo
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                StudentName = reader.GetString(reader.GetOrdinal("StudentName")),
                                ClassName = reader.GetString(reader.GetOrdinal("ClassName")),
                                SchoolName = reader.GetString(reader.GetOrdinal("SchoolName"))
                            });
                        }
                    }
                    LogOperation(cmd.CommandText);
                }
            }
            return studentsDetails;
        }
        // 根据学生ID和学生名删除学生
        public bool DeleteStudentByIdAndName(int studentId, string studentName)
        {
            bool isDeleted = false;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(
                    @"DELETE FROM Student " +
                    "WHERE StudentID = @StudentID AND StudentName = @StudentName", conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@StudentName", studentName);
                    int result = cmd.ExecuteNonQuery();
                    isDeleted = result > 0;
                    LogOperation(cmd.CommandText);
                }
            }
            return isDeleted;
        }
        // 记录操作到日志表
        private void LogOperation(string operateSql)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(
                    @"INSERT INTO Log (OperationSql, OperationTime) VALUES (@OperationSql, @OperationTime)", conn))
                {
                    cmd.Parameters.AddWithValue("@OperationSql", operateSql);
                    cmd.Parameters.AddWithValue("@OperationTime", DateTime.Now); // 记录当前时间
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // 获取所有日志对象列表
        public List<Log> GetAllLogs()
        {
            List<Log> logs = new List<Log>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Log", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Log log = new Log
                            {
                                LogID = reader.GetInt32("LogID"),
                                OperationSql = reader.GetString("OperationSql"),
                                OperationTime = reader.GetDateTime("OperationTime")
                            };
                            logs.Add(log);
                        }
                    }
                }
            }
            return logs;
        }
    }
}
