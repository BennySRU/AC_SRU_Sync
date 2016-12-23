using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRsync.Signature;
using System.IO;
using FastRsync.Delta;
using FastRsync.Diagnostics;

namespace AC_SRU_Sync
{
    public class RSyncHelper
    {
        public static void CreateSignatur(string basisFilePath, string signatureFilePath)
        {

            var signatureBuilder = new SignatureBuilder();
            using (var basisStream = new FileStream(basisFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var signatureStream = new FileStream(signatureFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                signatureBuilder.Build(basisStream, new SignatureWriter(signatureStream));
            }
        }

        public static void GetDelta()
        {
            //var delta = new DeltaBuilder();
            //builder.ProgressReporter = new ConsoleProgressReporter();
            //using (var newFileStream = new FileStream(newFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            //using (var signatureStream = new FileStream(signatureFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            //using (var deltaStream = new FileStream(deltaFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
            //{
            //    delta.BuildDelta(newFileStream, new SignatureReader(signatureStream, delta.ProgressReporter), new AggregateCopyOperationsDecorator(new BinaryDeltaWriter(deltaStream)));
            //}
        }
    }
}
