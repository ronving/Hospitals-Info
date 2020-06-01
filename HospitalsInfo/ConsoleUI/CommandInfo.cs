﻿using System;

namespace HospitalsInfo.ConsoleUI
{
    public delegate void Command();
    public struct CommandInfo
    {
        public string name;
        public Command command;

        public CommandInfo(string name, Command command) {
            this.name = name;
            this.command = command;
        }
    }
}
