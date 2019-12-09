using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchAutoTest.TaskExecuter
{
    public enum TASK_STATUS
    {
        UNEXECUTION,
        EXECUTION,
        PROCESSED
    };

    // enum定義のヘルパクラス
    public static class TASK_STSTUS_EXT
    {
        // TASK_TYPE に対する拡張メソッドの定義
        public static string DisplayName(this TASK_STATUS type)
        {
            string[] names = { "未実行", "実行中", "完了" };
            return names[(int)type];
        }
    }
}
