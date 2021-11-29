﻿using System;
using System.Linq;

namespace Nohwnd.AttachVS.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? pid = ParsePid(args, position: 0);
            int? vsPid = ParsePid(args, position: 1);

            var exitCode = DebuggerUtility.AttachVSToProcess(pid, vsPid) ? 0 : 1;
            Environment.Exit(exitCode);
        }

        private static int? ParsePid(string[] args, int position)
        {
            var id = args.Skip(position).Take(1).SingleOrDefault();
            int? pid = id == null
                ? null
                : int.TryParse(id, out var i)
                    ? i
                    : null;
            return pid;
        }
    }
}