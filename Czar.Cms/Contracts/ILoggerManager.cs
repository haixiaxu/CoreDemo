using System;

namespace Contracts
{
    /// <summary>
    /// 日志管理
    /// </summary>
    public interface ILoggerManager
    {
        /// <summary>
        /// 信息消息
        /// </summary>
        /// <param name="message"></param>
        void LogInfo(string message);
        /// <summary>
        ///警告信息
        /// </summary>
        /// <param name="message"></param>
        void LogWarn(string message);
        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="message"></param>
        void LogDebug(string message);
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);
        
    }
}
