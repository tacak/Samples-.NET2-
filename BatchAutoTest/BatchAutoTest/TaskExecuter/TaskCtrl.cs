using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchAutoTest.TaskExecuter
{
    public enum TASK_CTRL
    {
        ERROR_STOP,
        WARNING_STOP,
        NON_STOP
    };

    // enum定義のヘルパクラス
    public static class TASK_CTRL_EXT
    {
        // TASK_TYPE に対する拡張メソッドの定義
        public static string DisplayName(this TASK_CTRL type)
        {
            string[] names = { "エラーで停止", "警告で停止", "停止しない" };
            return names[(int)type];
        }
    }
}
