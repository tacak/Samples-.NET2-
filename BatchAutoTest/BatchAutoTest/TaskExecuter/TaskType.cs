using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchAutoTest.TaskExecuter
{
    public enum TASK_TYPE
    {
        COMMAND,
        FILE_DOWNLOAD,
        FILE_UPLOAD,
        SQL
    };

    // enum定義のヘルパクラス
    public static class TASK_TYPE_EXT
    {
        // TASK_TYPE に対する拡張メソッドの定義
        public static string DisplayName(this TASK_TYPE type)
        {
            string[] names = { "コマンド実行", "IF転送(DL)", "IF転送(UL)", "SQL実行" };
            return names[(int)type];
        }
    }
}
