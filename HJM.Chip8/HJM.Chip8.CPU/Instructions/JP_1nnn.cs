﻿using HJM.Chip8.CPU.Changes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HJM.Chip8.CPU.Instructions
{
    /// <summary>
    /// 1nnn - JP addr
    /// Jump to location nnn.
    /// The interpreter sets the program counter to nnn.
    /// </summary>
    public class JP_1nnn : Instruction
    {
        public override CPUStateChange Execute(in CPUState state)
        {
            CPUStateChange stateChange = new CPUStateChange();

            Change<ushort> programCounterChange = new Change<ushort>();
            programCounterChange.OldValue = state.ProgramCounter;
            programCounterChange.NewValue = (ushort)(state.OpCode & 0x0FFF);

            return stateChange;
        }
    }
}