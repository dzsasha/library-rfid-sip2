using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace IS.RFID.Bibliotheca
{
    public static class External
    {
         //Defines the interface for BiblioChip.dll
     
        const string lib_name = "BiblioChip.dll";

        [DllImport(lib_name)] 
        public static extern void BibAcquire();
        [DllImport(lib_name)] 
        public static extern void BibRelease();

        [DllImport(lib_name)]
        public static extern int BibOpenReader();

        [DllImport(lib_name)]
        public static extern int BibOpenReaderMulti(string connection_params);

        [DllImport(lib_name)]
        public static extern int BibSelectReader(int reader_handle);

        [DllImport(lib_name)]
        public static extern int BibCloseReader();

        [DllImport(lib_name)]
        public static extern string BibVersion();

        [DllImport(lib_name)]
        public static extern string BibResult();

        [DllImport(lib_name)]
        public static extern int BibInventory();

        [DllImport(lib_name)]
        public static extern int BibSwitchOffRF();

        [DllImport(lib_name)]
        public static extern int BibInitItemLabel(int trp);

        [DllImport(lib_name)]
        public static extern int BibInitUserCard(int trp);

        [DllImport(lib_name)]
        public static extern int BibReadUsedPages(int trp);

        [DllImport(lib_name)]
        public static extern int BibWriteChangedPages(int trp);

        [DllImport(lib_name, EntryPoint="BibGetTransponderUID")]
        private static extern int _BibGetTransponderUID(int trp, ref IntPtr uid);

        [DllImport(lib_name)]
        public static extern int BibGetTransponderType(int trp);

        [DllImport(lib_name)]
        public static extern int BibGetDataModelID(int trp);

        [DllImport(lib_name)]
        public static extern int BibGetDataModelVersion(int trp);

        [DllImport(lib_name)]
        public static extern int BibGetIsItemLabel(int trp);

        [DllImport(lib_name)]
        public static extern int BibGetIsUserCard(int trp);

        [DllImport(lib_name, EntryPoint="BibGetLibraryCountryID")]
        private static extern int _BibGetLibraryCountryID(int trp, ref IntPtr id);
        [DllImport(lib_name)]
        public static extern int BibSetLibraryCountryID(int trp, string id);

        [DllImport(lib_name, EntryPoint="BibGetLibraryInstitutionID")]
        private static extern int _BibGetLibraryInstitutionID(int trp, ref IntPtr id);
        [DllImport(lib_name)]
        public static extern int BibSetLibraryInstitutionID(int trp, string id);

        [DllImport(lib_name, EntryPoint="BibLibraryBranchID")]
        private static extern int _BibGetLibraryBranchID(int trp, ref IntPtr id);
        [DllImport(lib_name)]
        public static extern int BibSetLibraryBranchID(int trp, string id);
            
        [DllImport(lib_name, EntryPoint="BibGetLibraryDepartmentID")]
        private static extern int _BibGetLibraryDepartmentID(int trp, ref IntPtr id);
        [DllImport(lib_name)]
        public static extern int BibSetLibraryDepartmentID(int trp, string id);

        [DllImport(lib_name, EntryPoint="BibGetItemID")]
        private static extern int _BibGetItemID(int trp, ref IntPtr id);
        [DllImport(lib_name)]
        public static extern int BibSetItemID(int trp, string id);

        [DllImport(lib_name, EntryPoint="BibGetItemType")]
        private static extern int _BibGetItemType(int trp, ref IntPtr typ);
        [DllImport(lib_name)]
        public static extern int BibSetItemType(int trp, string typ);

        [DllImport(lib_name, EntryPoint="BibGetItemISBN")]
        private static extern int _BibGetItemISBN(int trp, ref IntPtr isbn);
        [DllImport(lib_name)]
        public static extern int BibSetItemISBN(int trp, string isbn);

        [DllImport(lib_name, EntryPoint="BibGetItemTitle")]
        private static extern int _BibGetItemTitle(int trp, ref IntPtr title);
        [DllImport(lib_name)]
        public static extern int BibSetItemTitle(int trp, string title);

        [DllImport(lib_name, EntryPoint="BibGetItemAuthor")]
        private static extern int _BibGetItemAuthor(int trp, ref IntPtr author);
        [DllImport(lib_name)]
        public static extern int BibSetItemAuthor(int trp, string author);

        [DllImport(lib_name, EntryPoint="BibGetItemSignature")]
        private static extern int _BibGetItemSignature(int trp, ref IntPtr signature);
        [DllImport(lib_name)]
        public static extern int BibSetItemSignature(int trp, string signature);

        [DllImport(lib_name, EntryPoint="BibGetItemLocation")]
        private static extern int _BibGetItemLocation(int trp, ref IntPtr location);
        [DllImport(lib_name)]
        public static extern int BibSetItemLocation(int trp, string location);

        [DllImport(lib_name)]
        public static extern int BibGetItemPartsInPackage(int trp);
        [DllImport(lib_name)]
        public static extern int BibSetItemPartsInPackage(int trp, int parts);

        [DllImport(lib_name)]
        public static extern int BibGetItemPartOfPackage(int trp);
        [DllImport(lib_name)]
        public static extern int BibSetItemPartOfPackage(int trp, int part);

        [DllImport(lib_name)]
        public static extern int BibGetItemCheckOutAllowed(int trp);
        [DllImport(lib_name)]
        public static extern int BibSetItemCheckOutAllowed(int trp, int flag);

        [DllImport(lib_name)]
        public static extern int BibGetItemCheckedOut(int trp);
        [DllImport(lib_name)]
        public static extern int BibSetItemCheckedOut(int trp, int flag);

        [DllImport(lib_name, EntryPoint="BibGetItemCheckOutDate")]
        private static extern int _BibGetItemCheckOutDate(int trp, ref IntPtr date);
        [DllImport(lib_name)]
        public static extern int BibSetItemCheckOutDate(int trp, string date);

        [DllImport(lib_name, EntryPoint="BibGetItemBorrowerID")]
        private static extern int _BibGetItemBorrowerID(int trp, ref IntPtr id);
        [DllImport(lib_name)]
        public static extern int BibSetItemBorrowerID(int trp, string id);

        [DllImport(lib_name)]
        public static extern int BibGetItemOnHold(int trp);
        [DllImport(lib_name)]
        public static extern int BibSetItemOnHold(int trp, int flag);

        [DllImport(lib_name, EntryPoint="BibGetUserID")]
        private static extern int _BibGetUserID(int trp, ref IntPtr id);
        [DllImport(lib_name)]
        public static extern int BibSetUserID(int trp, string id);

        [DllImport(lib_name, EntryPoint="BibGetUserGroupID")]
        private static extern int _BibGetUserGroupID(int trp, ref IntPtr id);
        [DllImport(lib_name)]
        public static extern int BibSetUserGroupID(int trp, string id);

        [DllImport(lib_name, EntryPoint="BibGetUserFirstName")]
        private static extern int _BibGetUserFirstName(int trp, ref IntPtr name);
        [DllImport(lib_name)]
        public static extern int BibSetUserFirstName(int trp, string name);

        [DllImport(lib_name, EntryPoint="BibGetUserLastName")]
        private static extern int _BibGetUserLastName(int trp, ref IntPtr name);
        [DllImport(lib_name)]
        public static extern int BibSetUserLastName(int trp, string name);
        
        [DllImport(lib_name, EntryPoint="BibGetUserSalutation")]
        private static extern int _BibGetUserSalutation(int trp, ref IntPtr salut);
        [DllImport(lib_name)]
        public static extern int BibSetUserSalutation(int trp, string salut);
        
        [DllImport(lib_name, EntryPoint="BibGetUserLanguage")]
        private static extern int _BibGetUserLanguage(int trp, ref IntPtr language);
        [DllImport(lib_name)]
        public static extern int BibSetUserLanguage(int trp, string language);

        [DllImport(lib_name)]
        public static extern int BibCheckUserPIN(int trp, string pin);
        [DllImport(lib_name)]
        public static extern int BibSetUserPIN(int trp, string pin);
    
        [DllImport(lib_name, EntryPoint="BibGetUserExpirationDate")]
        private static extern int _BibGetUserExpirationDate(int trp, ref IntPtr date);
        [DllImport(lib_name)]
        public static extern int BibSetUserExpirationDate(int trp, string date);

        [DllImport(lib_name, EntryPoint="BibGetApplicationData0")]
        private static extern int _BibGetApplicationData0(int trp, ref IntPtr data);
        [DllImport(lib_name)]
        public static extern int BibSetApplicationData0(int trp, string data);

        [DllImport(lib_name, EntryPoint="BibGetApplicationData1")]
        private static extern int _BibGetApplicationData1(int trp, ref IntPtr data);
        [DllImport(lib_name)]
        public static extern int BibSetApplicationData1(int trp, string data);
    
        [DllImport(lib_name, EntryPoint="BibGetApplicationData2")]
        private static extern int _BibGetApplicationData2(int trp, ref IntPtr data);
        [DllImport(lib_name)]
        public static extern int BibSetApplicationData2(int trp, string data);

        [DllImport(lib_name, EntryPoint="BibGetApplicationData3")]
        private static extern int _BibGetApplicationData3(int trp, ref IntPtr data);
        [DllImport(lib_name)]
        public static extern int BibSetApplicationData3(int trp, string data);

        [DllImport(lib_name, EntryPoint="BibGetApplicationData4")]
        private static extern int _BibGetApplicationData4(int trp, ref IntPtr data);
        [DllImport(lib_name)]
        public static extern int BibSetApplicationData4(int trp, string data);

        [DllImport(lib_name, EntryPoint="BibGetApplicationData5")]
        private static extern int _BibGetApplicationData5(int trp, ref IntPtr data);
        [DllImport(lib_name)]
        public static extern int BibSetApplicationData5(int trp, string data);

        [DllImport(lib_name, EntryPoint="BibGetApplicationData6")]
        private static extern int _BibGetApplicationData6(int trp, ref IntPtr data);
        [DllImport(lib_name)]
        public static extern int BibSetApplicationData6(int trp, string data);

        [DllImport(lib_name, EntryPoint="BibGetApplicationData7")]
        private static extern int _BibGetApplicationData7(int trp, ref IntPtr data);
        [DllImport(lib_name)]
        public static extern int BibSetApplicationData7(int trp, string data);


        //Marshalling
        public static int BibGetTransponderUID(int trp, ref string uid)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetTransponderUID(trp, ref ptr);
            uid = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetLibraryCountryID(int trp, ref string id)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetLibraryCountryID(trp, ref ptr);
            id = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetLibraryInstitutionID(int trp, ref string id)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetLibraryInstitutionID(trp, ref ptr);
            id = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetLibraryBranchID(int trp, ref string id)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetLibraryBranchID(trp, ref ptr);
            id = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetLibraryDepartmentID(int trp, ref string id)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetLibraryDepartmentID(trp, ref ptr);
            id = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetItemID(int trp, ref string id)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetItemID(trp, ref ptr);
            id = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetItemType(int trp, ref string typ)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetItemType(trp, ref ptr);
            typ= Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetItemISBN(int trp, ref string isbn)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetItemISBN(trp, ref ptr);
            isbn = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetItemTitle(int trp, ref string title)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetItemTitle(trp, ref ptr);
            title = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetItemAuthor(int trp, ref string author)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetItemAuthor(trp, ref ptr);
            author = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetItemSignature(int trp, ref string signature)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetItemSignature(trp, ref ptr);
            signature = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetItemLocation(int trp, ref string location)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetItemLocation(trp, ref ptr);
            location = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetItemCheckOutDate(int trp, ref string date)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetItemCheckOutDate(trp, ref ptr);
            date = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetItemBorrowerID(int trp, ref string id)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetItemBorrowerID(trp, ref ptr);
            id = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetUserID(int trp, ref string id)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetUserID(trp, ref ptr);
            id = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetUserGroupID(int trp, ref string id)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetUserGroupID(trp, ref ptr);
            id = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetUserFirstName(int trp, ref string name)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetUserFirstName(trp, ref ptr);
            name = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetUserLastName(int trp, ref string name)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetUserLastName(trp, ref ptr);
            name = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetUserSalutation(int trp, ref string salut)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetUserSalutation(trp, ref ptr);
            salut = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetUserLanguage(int trp, ref string language)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetUserLanguage(trp, ref ptr);
            language = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetUserExpirationDate(int trp, ref string date)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetUserExpirationDate(trp, ref ptr);
            date = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetApplicationData0(int trp, ref string data)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetApplicationData0(trp, ref ptr);
            data = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetApplicationData1(int trp, ref string data)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetApplicationData1(trp, ref ptr);
            data = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetApplicationData2(int trp, ref string data)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetApplicationData2(trp, ref ptr);
            data = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetApplicationData3(int trp, ref string data)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetApplicationData3(trp, ref ptr);
            data = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetApplicationData4(int trp, ref string data)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetApplicationData4(trp, ref ptr);
            data = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetApplicationData5(int trp, ref string data)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetApplicationData5(trp, ref ptr);
            data = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetApplicationData6(int trp, ref string data)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetApplicationData6(trp, ref ptr);
            data = Marshal.PtrToStringAnsi(ptr);
            return result;
        }
        public static int BibGetApplicationData7(int trp, ref string data)
        {
            IntPtr ptr = IntPtr.Zero;
            int result = _BibGetApplicationData7(trp, ref ptr);
            data = Marshal.PtrToStringAnsi(ptr);
            return result;
        }


    }
}
