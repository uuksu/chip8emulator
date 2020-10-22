﻿using HJM.Chip8.CPU.Changes;
using HJM.Chip8.CPU.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HJM.Chip8.CPU.Instructions
{
    public class _0000 : Instruction
    {
        private Dictionary<int, Instruction> Instructions = new Dictionary<int, Instruction>();
        public _0000()
        {
            Instructions.Add(0x00E0, new CLS_00E0());
            Instructions.Add(0x00EE, new RET_00EE());
        }

        public override CPUStateChange Execute(in CPUState state)
        {
            Instruction? instruction = Instructions.GetValueOrDefault(state.OpCode & 0x00FF);

            if (instruction == null)
            {
                throw new InvalidOpCodeException(state.OpCode);
            }

            return instruction.Execute(state);
        }
    }
}