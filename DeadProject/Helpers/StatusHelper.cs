using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeadProject.Helpers
{
    public enum Status
    {
        Error,
        Warning,
        Success
    }
    public static class StatusHelper
    {
        public static string StatusView(Status status , string content)
        {
            switch (status)
            {
                case Status.Error:
                    return "<div class='alert alert-danger '><strong> Danger!</strong>"+content+"</div> ";
                case Status.Success:
                    return "<div class='alert alert-success '><strong> Success!</strong>"+content+"</div> ";
                case Status.Warning:
                    return "<div class='alert alert-warning '><strong> Success!</strong>"+content+"</div> ";
            }
            return content;

        }
    }
}