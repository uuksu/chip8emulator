﻿using HJM.Chip8.CPU.Changes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HJM.Chip8.CPU.Instructions
{
    /// <summary>
    /// 2nnn - CALL addr
    ///  Call subroutine at nnn.
    /// The interpreter increments the stack pointer, then puts the current PC on the top of the stack. The PC is then set to nnn.
    /// </summary>
    public class CALL_2nnn : Instruction
    {
        public override CPUStateChange Execute(in CPUState state)
        {
            CPUStateChange stateChange = new CPUStateChange();

            StackChange stackChange = new StackChange();

            AddressChange<ushort> stackAddressChange = new AddressChange<ushort>
            {
                AddressChanged = state.StackPointer,
                OldValue = state.Stack[state.StackPointer],
                NewValue = state.ProgramCounter
            };

            stackChange.AddressStackChange = stackAddressChange;

            Change<ushort> stackPointerChange = new Change<ushort>
            {
                OldValue = state.StackPointer,
                NewValue = (ushort)(state.StackPointer + 1)
            };

            stackChange.StackPointerChange = stackPointerChange;

            stateChange.StackChange = stackChange;

            ushort nnn = (ushort)(state.OpCode & 0x0FFF);

            Change<ushort> programCounterChange = new Change<ushort>
            {
                OldValue = state.ProgramCounter,
                NewValue = nnn
            };

            stateChange.ProgramCounterChange = programCounterChange;

            return stateChange;
        }
    }
}
