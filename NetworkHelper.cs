using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MRZReader
{
    public static class NetworkShare
    {
        /// <summary>
        /// Connects to the remote share
        /// </summary>
        /// <returns>Null if successful, otherwise error message.</returns>
        public static string ConnectToShare(string uri, string username, string password)
        {
            //Create netresource and point it at the share
            NETRESOURCE nr = new NETRESOURCE();
            nr.dwType = RESOURCETYPE_DISK;
            nr.lpRemoteName = @uri;

            //Create the share
            int ret = WNetUseConnection(IntPtr.Zero, nr, password, username, 0, null, null, null);

            //Check for errors
            if (ret == NO_ERROR)
                return null;
            else
                return GetError(ret);
        }

        /// <summary>
        /// Remove the share from cache.
        /// </summary>
        /// <returns>Null if successful, otherwise error message.</returns>
        public static string DisconnectFromShare(string uri, bool force)
        {
            //remove the share
            int ret = WNetCancelConnection(uri, force);

            //Check for errors
            if (ret == NO_ERROR)
                return null;
            else
                return GetError(ret);
        }

        #region P/Invoke Stuff
        [DllImport("Mpr.dll")]
        private static extern int WNetUseConnection(
            IntPtr hwndOwner,
            NETRESOURCE lpNetResource,
            string lpPassword,
            string lpUserID,
            int dwFlags,
            string lpAccessName,
            string lpBufferSize,
            string lpResult
            );

        [DllImport("Mpr.dll")]
        private static extern int WNetCancelConnection(
            string lpName,
            bool fForce
            );

        [StructLayout(LayoutKind.Sequential)]
        private class NETRESOURCE
        {
            public int dwScope = 0;
            public int dwType = 0;
            public int dwDisplayType = 0;
            public int dwUsage = 0;
            public string lpLocalName = "";
            public string lpRemoteName = "";
            public string lpComment = "";
            public string lpProvider = "";
        }

        #region Consts
        const int RESOURCETYPE_DISK = 0x00000001;
        const int CONNECT_UPDATE_PROFILE = 0x00000001;
        #endregion

        #region Errors
        const int NO_ERROR = 0;

        const int ERROR_ACCESS_DENIED = 5;
        const int ERROR_ALREADY_ASSIGNED = 85;
        const int ERROR_BAD_DEVICE = 1200;
        const int ERROR_BAD_NETPATH = 53;
        const int ERROR_NETNAME_DELETED = 64;
        const int ERROR_BAD_NET_NAME = 67;
        const int ERROR_BAD_PROVIDER = 1204;
        const int ERROR_CANCELLED = 1223;
        const int ERROR_EXTENDED_ERROR = 1208;
        const int ERROR_INVALID_ADDRESS = 487;
        const int ERROR_INVALID_PARAMETER = 87;
        const int ERROR_INVALID_PASSWORD = 1216;
        const int ERROR_MORE_DATA = 234;
        const int ERROR_NO_MORE_ITEMS = 259;
        const int ERROR_NO_NET_OR_BAD_PATH = 1203;
        const int ERROR_NO_NETWORK = 1222;
        const int ERROR_SESSION_CREDENTIAL_CONFLICT = 1219;
        const int ERROR_LOGON_FAILURE = 1326; 

        const int ERROR_BAD_PROFILE = 1206;
        const int ERROR_CANNOT_OPEN_PROFILE = 1205;
        const int ERROR_DEVICE_IN_USE = 2404;
        const int ERROR_NOT_CONNECTED = 2250;
        const int ERROR_OPEN_FILES = 2401;

        private struct ErrorClass
        {
            public int num;
            public string message;
            public ErrorClass(int num, string message)
            {
                this.num = num;
                this.message = message;
            }
        }

        private static ErrorClass[] ERROR_LIST = new ErrorClass[] {
        new ErrorClass(ERROR_ACCESS_DENIED, "Err Msg: Access Denied"),
        new ErrorClass(ERROR_ALREADY_ASSIGNED, "Err Msg: Already Assigned"),
        new ErrorClass(ERROR_BAD_DEVICE, "Err Msg: Bad Device"),
        new ErrorClass(ERROR_BAD_NET_NAME, "Err Msg: Bad Net Name"),
        new ErrorClass(ERROR_BAD_PROVIDER, "Err Msg: Bad Provider"),
        new ErrorClass(ERROR_CANCELLED, "Err Msg: Cancelled"),
        new ErrorClass(ERROR_EXTENDED_ERROR, "Err Msg: Extended Err Msg"),
        new ErrorClass(ERROR_INVALID_ADDRESS, "Err Msg: Invalid Address"),
        new ErrorClass(ERROR_INVALID_PARAMETER, "Err Msg: Invalid Parameter"),
        new ErrorClass(ERROR_INVALID_PASSWORD, "Err Msg: Invalid Password"),
        new ErrorClass(ERROR_MORE_DATA, "Err Msg: More Data"),
        new ErrorClass(ERROR_NO_MORE_ITEMS, "Err Msg: No More Items"),
        new ErrorClass(ERROR_NO_NET_OR_BAD_PATH, "Err Msg: No Net Or Bad Path"),
        new ErrorClass(ERROR_NO_NETWORK, "Err Msg: No Network"),
        new ErrorClass(ERROR_BAD_PROFILE, "Err Msg: Bad Profile"),
        new ErrorClass(ERROR_CANNOT_OPEN_PROFILE, "Err Msg: Cannot Open Profile"),
        new ErrorClass(ERROR_DEVICE_IN_USE, "Err Msg: Device In Use"),
        new ErrorClass(ERROR_EXTENDED_ERROR, "Err Msg: Extended Error"),
        new ErrorClass(ERROR_NOT_CONNECTED, "Err Msg: Not Connected"),
        new ErrorClass(ERROR_OPEN_FILES, "Err Msg: Open Files"),
        new ErrorClass(ERROR_SESSION_CREDENTIAL_CONFLICT, "Err Msg: Credential Conflict"),
        new ErrorClass(ERROR_LOGON_FAILURE, "Err Msg: Logon Failure Due To Bad Username Or Password"),
        new ErrorClass(ERROR_NETNAME_DELETED, "Err Msg: Internet Not Connected Or Net Name Deleted"),
        new ErrorClass(ERROR_BAD_NETPATH, "Err Msg: Internet Not Connected Or Bad Net Path"),
    };

        private static string GetError(int errNum)
        {
            foreach (ErrorClass er in ERROR_LIST)
            {
                if (er.num == errNum) return er.message;
            }
            return "Error: Unknown, " + errNum;
        }
        #endregion

        #endregion
    }
}
