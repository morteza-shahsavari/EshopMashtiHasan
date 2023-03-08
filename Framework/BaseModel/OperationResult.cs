using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.BaseModel
{
    public class OperationResult
    {
        public int? RecordID { get; private set; }
        public string Message { get; private set; }
        public string Operation { get; private set; }
        public bool Success { get; private set; }
        public DateTime OperationDate { get; private set; }
        public string TableName { get; private set; }
        public OperationResult(string Operation, string TableName)
        {
            Success = false;
            this.Operation = Operation;
            this.TableName = TableName;
            this.TableName = TableName;

        }
        public OperationResult(string Operation, string TableName, int RecordID)
        {
            Success = false;
            this.Operation = Operation;
            this.TableName = TableName;
            this.TableName = TableName;
            this.RecordID = RecordID;

        }

        public OperationResult ToSuccess(int? RecordID, string Message)
        {
            Success = true;
            this.Message = Message;
            this.RecordID = RecordID;
            return this;
        }
        public OperationResult ToSuccess(string Message)
        {
            Success = true;
            this.Message = Message;

            return this;
        }
        public OperationResult ToFail(int? RecordID, string Message)
        {
            Success = false;
            this.Message = Message;
            this.RecordID = RecordID;
            return this;
        }
        public OperationResult ToFail(string Message)
        {
            Success = false;
            this.Message = Message;
            return this;
        }
    }
}
