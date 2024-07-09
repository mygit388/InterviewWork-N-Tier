using InterviewWork.Data;
using InterviewWork.Models;
using InterviewWork.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace InterviewWork.Repository.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        DBConnections Db = new DBConnections();
        string procedureName;
        SqlParameter[] parameters = null;
        DataTable dt;
        

        public List<TaskModel> GetTasks(int ProfileId)
        {
            try
            {

                dt = new DataTable();
                List<TaskModel> taskList = new List<TaskModel>();
                procedureName = "sp_GetTasks";
                parameters = new SqlParameter[]
               {
                 new SqlParameter("@ProfileId", SqlDbType.Int) { Value=ProfileId }
               };
                dt = Db.ExecuteQuery(procedureName, parameters);
                foreach (DataRow dr in dt.Rows)
                {
                    taskList.Add(new TaskModel
                    {
                        Id = (int)dr["Id"],
                        ProfileId = (int)dr["ProfileId"],
                        TaskName = dr["TaskName"].ToString(),
                        TaskDescription = dr["TaskDescription"].ToString(),
                        StartTime = (DateTime)dr["StartTime"],
                        Status = (int)dr["Status"]
                    });
                }
                return taskList;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return null;
            }
        }

        public bool Insert(TaskModel model)
        {
            try
            {
                int id = 0;
                procedureName = "sp_AddTask";
                parameters = new SqlParameter[]
                {
                     new SqlParameter("@ProfileId", SqlDbType.Int) { Value = model.ProfileId },
                     new SqlParameter("@TaskName", SqlDbType.VarChar, 255) { Value = model.TaskName },
                     new SqlParameter("@TaskDescription", SqlDbType.VarChar, 255) { Value = model.TaskDescription },
                     new SqlParameter("@StartTime", SqlDbType.DateTime) { Value = model.StartTime },
                     new SqlParameter("@Status", SqlDbType.Int) { Value = model.Status }
                };
                id = Db.ExecuteNonQuery(procedureName, parameters);
                if (id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return false;
            }
        }

        public TaskModel TaskByID(int Id)
        {
            try
            {
                TaskModel task = null;
                procedureName = "sp_GetTaskByID";
                parameters = new SqlParameter[]
                {
                 new SqlParameter("@Id", SqlDbType.Int) { Value=Id }
                };
                dt = Db.ExecuteQuery(procedureName, parameters);
                if (dt.Rows.Count >= 1)
                {
                    task = new TaskModel
                    {
                        ProfileId = dt.Rows[0].Field<int>("ProfileId"),
                        TaskName = dt.Rows[0].Field<string>("TaskName"),
                        TaskDescription = dt.Rows[0].Field<string>("TaskDescription"),
                        StartTime = dt.Rows[0].Field<DateTime>("StartTime"),
                        Status = dt.Rows[0].Field<int>("Status"),
                    };
                }
                return task;

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return null;
            }
        }

        public bool Update(TaskModel model)
        {
            try
            {
                int id = 0;
                procedureName = "sp_UpdateTask";
                parameters = new SqlParameter[]
                {
                     new SqlParameter("Id", SqlDbType.Int) { Value = model.Id },
                     new SqlParameter("@ProfileId", SqlDbType.Int) { Value = model.ProfileId },
                     new SqlParameter("@TaskName", SqlDbType.VarChar, 255) { Value = model.TaskName },
                     new SqlParameter("@TaskDescription", SqlDbType.VarChar, 255) { Value = model.TaskDescription },
                     new SqlParameter("@StartTime", SqlDbType.DateTime) { Value = model.StartTime },
                     new SqlParameter("@Status", SqlDbType.Int) { Value = model.Status }
                };
                id = Db.ExecuteNonQuery(procedureName, parameters);
                if (id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return false;
            }
        }
        public void Delete(int Id)
        {
            try
            {
                procedureName = "sp_DeleteTask";
                parameters = new SqlParameter[]
                {
                      new SqlParameter("@ProfileId", SqlDbType.Int) { Value = Id },
                };
                Db.ExecuteNonQuery(procedureName, parameters);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }

    }
}
