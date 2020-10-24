﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HJM.Chip8.CPU.Changes
{
    /// <summary>
    /// Represents a change to the stack
    /// </summary>
    public class StackChange
    {
        public AddressChange<ushort> AddressStackChange { get; set; } = new AddressChange<ushort>();
        public Change<ushort> StackPointerChange { get; set; } = new Change<ushort>();
    }
}
