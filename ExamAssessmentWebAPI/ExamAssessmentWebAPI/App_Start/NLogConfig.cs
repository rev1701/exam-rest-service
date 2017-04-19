using NLog;

namespace ExamAssessmentWebAPI.App_Start
{
    public static class NLogConfig
    {
        public static Logger logger = LogManager.GetCurrentClassLogger(); //suggested readonly
    }
}