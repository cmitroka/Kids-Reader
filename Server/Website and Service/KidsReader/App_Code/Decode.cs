using System;
using System.Linq;
using System.Text;
public static class Decode
{
    public static string ConvertIDtoKey(string WhatToConvert)
    {
        string retVal = "";
        byte[] asciifromletter = Encoding.ASCII.GetBytes(WhatToConvert);
        int MagicVal = 0;
        int asciival;
        int iCycle = 0;
        if (WhatToConvert.Length < 8)
        {
            return RandomString(8);
        }
        for (byte idxfromletter = 0; idxfromletter < asciifromletter.Length; idxfromletter++)
        {
            iCycle++;
            string sCycle = iCycle.ToString();
            string sSingleCharCycle = sCycle.Substring(sCycle.Length - 1, 1);
            int iSingleCharCycle = Convert.ToInt32(sSingleCharCycle);
            asciival = asciifromletter[idxfromletter];
            int AddVal = GetAdjustedValFromASCII(asciival, iSingleCharCycle);
            MagicVal = MagicVal + AddVal;
        }
        retVal = MagicVal.ToString();
        return retVal;
    }

    private static int GetAdjustedValFromASCII(int ASCIIin, int pCycle)
    {
        //0=48...9=57
        //A=65...H=72
        //a=97...h=104
        Random random = new Random();
        int ASCIItoRet = 0;
        if (pCycle == 1)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 15; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 70; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 40; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 64; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 63; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 80; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 17; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 83; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 87; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 49; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 30; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 6; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 64; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 61; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 18; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 22; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 92; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 45; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 62; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 27; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 42; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 41; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 43; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 54; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 49; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 9; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 76; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 35; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 28; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 59; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 42; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 37; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 90; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 4; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 62; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 83; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 3; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 65; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 98; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 9; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 85; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 95; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 82; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 29; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 40; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 2; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 92; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 81; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 22; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 94; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        else if (pCycle == 2)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 26; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 79; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 11; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 34; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 39; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 76; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 37; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 35; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 10; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 59; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 5; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 11; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 26; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 73; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 84; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 49; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 61; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 59; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 73; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 9; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 33; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 85; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 23; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 41; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 19; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 72; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 34; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 98; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 89; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 31; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 81; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 24; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 44; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 94; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 73; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 93; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 63; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 91; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 17; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 34; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 37; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 54; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 73; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 45; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 6; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 89; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 81; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 27; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 61; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 55; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 35; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 78; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 1; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 66; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        else if (pCycle == 3)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 99; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 60; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 15; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 84; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 27; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 79; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 38; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 5; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 24; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 61; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 14; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 38; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 68; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 92; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 23; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 70; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 13; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 28; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 71; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 4; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 77; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 47; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 92; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 41; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 11; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 85; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 23; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 30; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 93; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 45; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 70; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 44; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 46; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 85; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 88; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 21; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 14; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 36; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 61; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 32; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 23; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 4; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 5; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 55; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 49; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 12; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 83; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 19; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 78; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 87; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 3; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 70; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 63; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 65; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 14; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 96; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 83; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        else if (pCycle == 4)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 58; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 42; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 21; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 38; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 28; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 12; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 44; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 1; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 20; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 83; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 85; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 42; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 83; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 69; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 31; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 86; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 32; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 35; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 98; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 25; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 69; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 48; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 2; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 23; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 64; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 58; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 1; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 43; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 37; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 43; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 80; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 99; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 33; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 32; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 78; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 7; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 61; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 80; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 24; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 70; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 91; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 85; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 20; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 91; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 71; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 6; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 15; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 76; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 34; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 15; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 98; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 82; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        else if (pCycle == 5)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 33; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 18; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 84; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 19; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 33; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 10; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 67; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 96; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 74; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 80; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 30; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 39; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 53; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 83; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 30; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 81; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 77; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 33; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 4; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 76; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 13; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 60; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 36; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 92; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 33; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 60; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 49; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 12; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 3; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 40; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 26; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 29; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 68; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 92; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 24; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 64; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 84; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 84; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 65; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 63; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 71; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 62; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 41; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 78; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 17; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 11; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 62; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 72; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 24; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 81; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 30; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 82; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        else if (pCycle == 6)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 95; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 89; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 69; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 84; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 39; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 67; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 93; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 22; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 17; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 64; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 44; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 1; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 6; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 65; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 94; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 54; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 68; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 6; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 64; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 98; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 11; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 73; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 96; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 65; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 90; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 46; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 63; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 82; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 61; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 84; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 86; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 80; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 94; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 98; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 55; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 96; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 81; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 69; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 75; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 43; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 73; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 96; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 67; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 42; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 72; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 42; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 15; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 29; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 6; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 19; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 96; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 75; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        else if (pCycle == 7)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 49; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 10; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 81; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 25; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 29; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 26; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 94; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 7; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 41; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 62; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 11; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 31; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 2; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 68; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 86; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 83; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 22; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 36; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 61; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 5; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 37; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 91; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 91; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 93; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 60; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 13; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 77; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 94; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 76; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 79; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 64; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 86; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 27; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 75; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 38; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 33; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 89; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 26; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 80; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 81; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 90; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 82; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 75; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 25; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 46; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 39; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 54; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 89; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 29; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 22; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 68; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 37; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 39; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        else if (pCycle == 8)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 68; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 22; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 26; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 40; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 60; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 94; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 99; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 14; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 63; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 74; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 42; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 31; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 79; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 46; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 19; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 90; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 74; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 33; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 72; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 15; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 75; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 27; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 61; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 99; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 13; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 45; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 13; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 72; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 73; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 75; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 49; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 82; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 44; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 29; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 32; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 11; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 20; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 41; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 64; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 4; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 24; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 70; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 23; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 34; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 94; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 90; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 55; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 72; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 32; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 86; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        else if (pCycle == 9)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 3; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 34; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 27; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 2; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 54; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 67; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 83; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 3; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 48; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 3; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 82; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 63; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 41; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 24; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 84; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 29; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 28; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 74; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 72; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 27; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 78; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 26; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 72; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 96; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 4; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 54; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 67; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 40; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 98; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 32; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 73; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 75; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 49; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 3; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 54; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 26; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 70; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 23; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 77; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 90; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 29; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 62; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 51; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 5; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 2; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 16; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 37; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 90; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 30; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 77; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 74; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 71; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 4; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 99; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 53; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        else if (pCycle == 0)
        {
            if (ASCIIin == 48) { ASCIItoRet = ASCIIin + 92; }
            else if (ASCIIin == 49) { ASCIItoRet = ASCIIin + 69; }
            else if (ASCIIin == 50) { ASCIItoRet = ASCIIin + 22; }
            else if (ASCIIin == 51) { ASCIItoRet = ASCIIin + 46; }
            else if (ASCIIin == 52) { ASCIItoRet = ASCIIin + 78; }
            else if (ASCIIin == 53) { ASCIItoRet = ASCIIin + 17; }
            else if (ASCIIin == 54) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 55) { ASCIItoRet = ASCIIin + 54; }
            else if (ASCIIin == 56) { ASCIItoRet = ASCIIin + 79; }
            else if (ASCIIin == 57) { ASCIItoRet = ASCIIin + 86; }
            else if (ASCIIin == 65) { ASCIItoRet = ASCIIin + 86; }
            else if (ASCIIin == 66) { ASCIItoRet = ASCIIin + 12; }
            else if (ASCIIin == 67) { ASCIItoRet = ASCIIin + 5; }
            else if (ASCIIin == 68) { ASCIItoRet = ASCIIin + 86; }
            else if (ASCIIin == 69) { ASCIItoRet = ASCIIin + 91; }
            else if (ASCIIin == 70) { ASCIItoRet = ASCIIin + 59; }
            else if (ASCIIin == 71) { ASCIItoRet = ASCIIin + 56; }
            else if (ASCIIin == 72) { ASCIItoRet = ASCIIin + 98; }
            else if (ASCIIin == 73) { ASCIItoRet = ASCIIin + 53; }
            else if (ASCIIin == 74) { ASCIItoRet = ASCIIin + 15; }
            else if (ASCIIin == 75) { ASCIItoRet = ASCIIin + 40; }
            else if (ASCIIin == 76) { ASCIItoRet = ASCIIin + 36; }
            else if (ASCIIin == 77) { ASCIItoRet = ASCIIin + 28; }
            else if (ASCIIin == 78) { ASCIItoRet = ASCIIin + 17; }
            else if (ASCIIin == 79) { ASCIItoRet = ASCIIin + 46; }
            else if (ASCIIin == 80) { ASCIItoRet = ASCIIin + 11; }
            else if (ASCIIin == 81) { ASCIItoRet = ASCIIin + 50; }
            else if (ASCIIin == 82) { ASCIItoRet = ASCIIin + 27; }
            else if (ASCIIin == 83) { ASCIItoRet = ASCIIin + 89; }
            else if (ASCIIin == 84) { ASCIItoRet = ASCIIin + 9; }
            else if (ASCIIin == 85) { ASCIItoRet = ASCIIin + 88; }
            else if (ASCIIin == 86) { ASCIItoRet = ASCIIin + 23; }
            else if (ASCIIin == 87) { ASCIItoRet = ASCIIin + 88; }
            else if (ASCIIin == 88) { ASCIItoRet = ASCIIin + 66; }
            else if (ASCIIin == 89) { ASCIItoRet = ASCIIin + 99; }
            else if (ASCIIin == 90) { ASCIItoRet = ASCIIin + 35; }
            else if (ASCIIin == 97) { ASCIItoRet = ASCIIin + 96; }
            else if (ASCIIin == 98) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 99) { ASCIItoRet = ASCIIin + 5; }
            else if (ASCIIin == 100) { ASCIItoRet = ASCIIin + 14; }
            else if (ASCIIin == 101) { ASCIItoRet = ASCIIin + 89; }
            else if (ASCIIin == 102) { ASCIItoRet = ASCIIin + 7; }
            else if (ASCIIin == 103) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 104) { ASCIItoRet = ASCIIin + 52; }
            else if (ASCIIin == 105) { ASCIItoRet = ASCIIin + 73; }
            else if (ASCIIin == 106) { ASCIItoRet = ASCIIin + 97; }
            else if (ASCIIin == 107) { ASCIItoRet = ASCIIin + 83; }
            else if (ASCIIin == 108) { ASCIItoRet = ASCIIin + 86; }
            else if (ASCIIin == 109) { ASCIItoRet = ASCIIin + 42; }
            else if (ASCIIin == 110) { ASCIItoRet = ASCIIin + 81; }
            else if (ASCIIin == 111) { ASCIItoRet = ASCIIin + 70; }
            else if (ASCIIin == 112) { ASCIItoRet = ASCIIin + 4; }
            else if (ASCIIin == 113) { ASCIItoRet = ASCIIin + 5; }
            else if (ASCIIin == 114) { ASCIItoRet = ASCIIin + 87; }
            else if (ASCIIin == 115) { ASCIItoRet = ASCIIin + 48; }
            else if (ASCIIin == 116) { ASCIItoRet = ASCIIin + 8; }
            else if (ASCIIin == 117) { ASCIItoRet = ASCIIin + 64; }
            else if (ASCIIin == 118) { ASCIItoRet = ASCIIin + 42; }
            else if (ASCIIin == 119) { ASCIItoRet = ASCIIin + 57; }
            else if (ASCIIin == 120) { ASCIItoRet = ASCIIin + 35; }
            else if (ASCIIin == 121) { ASCIItoRet = ASCIIin + 4; }
            else if (ASCIIin == 122) { ASCIItoRet = ASCIIin + 29; }
            else { ASCIItoRet = ASCIIin + random.Next(50, 999); }
        }
        return ASCIItoRet;
    }
    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public static string RandomStringAlphaCaps(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
