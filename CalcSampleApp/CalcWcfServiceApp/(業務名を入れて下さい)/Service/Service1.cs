using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalcWcfServiceApp._業務名を入れて下さい_.Service
{
    [ServiceContract]
    public class Service1
    {
        [OperationContract]
        public void DoWork()
        {
        }
    }

    // 適切なフォルダ名に変更してから、
    // [新しい項目の追加]で、Terasolunaの WCFサービスファイルを再度作成てください。

    // この cs ファイルは、業務プロジェクトの対応するフォルダに移動して下さい。
    // このファイルの名前空間と、業務プロジェクトの名前空間が同じになるような場所に移動します。
    // クラス名とsvcファイル名は、同じにして下さい。
}
