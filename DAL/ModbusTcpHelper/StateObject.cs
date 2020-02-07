
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL

{
    public class StateObject
    {
        /// <summary>
        ///  Client socket. 
        /// </summary>
        public Socket workSocket = null;
        /// <summary>
        ///  Size of receive buffer.
        /// </summary>
        public const int BufferSize = 256;
        /// <summary>
        /// Receive buffer.
        /// </summary>
        public byte[] buffer = new byte[BufferSize];
        
    }
}
