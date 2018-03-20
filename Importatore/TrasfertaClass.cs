using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.IO;
using FileHelpers;
using FileHelpers.Dynamic;
using System.Diagnostics;
using FileHelpers.Detection;

namespace Importatore
{
    [DelimitedRecord("|")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TrasfertaClass
    {
        private string mTrasfertaID;
        private string mCID;
        private string mNominativo;
        private DateTime mDataInizioTrasferta;
        private DateTime mDataFineTrasferta;
        private string mNumeroTrasferta;
        private string mPaeseTrasferta;
        private string mLocalitaTrasferta;
        private string mStatoTrasferta;

        public string TrasfertaID
        {
            get { return mTrasfertaID; }
            set { mTrasfertaID = value; }
        }

        public string CID
        {
            get { return mCID; }
            set { mCID = value; }
        }

        public string Nominativo
        {
            get { return mNominativo; }
            set { mNominativo = value; }
        }

        public DateTime DataInizioTrasferta
        {
            get { return mDataInizioTrasferta; }
            set { mDataInizioTrasferta = value; }
        }

        public DateTime DataFineTrasferta
        {
            get { return mDataFineTrasferta; }
            set { mDataFineTrasferta = value; }
        }

        public string NumeroTrasferta
        {
            get { return mNumeroTrasferta; }
            set { mNumeroTrasferta = value; }
        }

        public string PaeseTrasferta
        {
            get { return mPaeseTrasferta; }
            set { mPaeseTrasferta = value; }
        }

        public string LocalitaTrasferta
        {
            get { return mLocalitaTrasferta; }
            set { mLocalitaTrasferta = value; }
        }

        public string StatoTrasferta
        {
            get { return mStatoTrasferta; }
            set { mStatoTrasferta = value; }
        }


        //-> To display in the PropertyGrid.
        public override string ToString()
        {
            return TrasfertaID + " - " + NumeroTrasferta + ", " + Nominativo + " - " + CID;
        }
    }
}
