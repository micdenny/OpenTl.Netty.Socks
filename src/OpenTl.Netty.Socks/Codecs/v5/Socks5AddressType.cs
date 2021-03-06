﻿/*
 * Copyright 2013 The Netty Project
 *
 * The Netty Project licenses this file to you under the Apache License,
 * version 2.0 (the "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at:
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

using System;

namespace OpenTl.Netty.Socks.Codecs.Socksx.v5
{
    /**
 * The type of address in {@link Socks5CommandRequest} and {@link Socks5CommandResponse}.
 */
    public sealed class Socks5AddressType : IComparable<Socks5AddressType>
    {
        public static readonly Socks5AddressType Pv4 = new Socks5AddressType(0x01, "IPv4");

        public static readonly Socks5AddressType Domain = new Socks5AddressType(0x03, "DOMAIN");

        public static readonly Socks5AddressType Pv6 = new Socks5AddressType(0x04, "IPv6");

        private readonly string _name;

        private string _text;

        public Socks5AddressType(int byteValue, string name = "UNKNOWN")
        {
            ByteValue = (byte) byteValue;
            _name = name;
        }

        public byte ByteValue { get; }

        public int CompareTo(Socks5AddressType other)
        {
            if (ReferenceEquals(this, other)) return 0;

            if (ReferenceEquals(null, other)) return 1;

            return ByteValue.CompareTo(other.ByteValue);
        }

        public override bool Equals(object obj)
        {
            return ByteValue == (obj as Socks5AddressType)?.ByteValue;
        }

        public override int GetHashCode()
        {
            return ByteValue;
        }

        public override string ToString()
        {
            var text = _text;
            if (text == null) _text = text = _name + '(' + (ByteValue & 0xFF) + ')';

            return text;
        }

        public static Socks5AddressType ValueOf(byte b)
        {
            switch (b)
            {
                case 0x01:
                    return Pv4;
                case 0x03:
                    return Domain;
                case 0x04:
                    return Pv6;
            }

            return new Socks5AddressType(b);
        }
    }
}