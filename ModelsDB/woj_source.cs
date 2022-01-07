//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SARSCOV2.ModelsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class woj_source
    {
        public int id { get; set; }
        public string wojewodztwo { get; set; }
        public Nullable<int> liczba_przypadkow { get; set; }
        public string liczba_na_10_tys_mieszkancow { get; set; }
        public Nullable<int> zgony { get; set; }
        public Nullable<int> zgony_w_wyniku_covid_bez_chorob_wspolistniejacych { get; set; }
        public Nullable<int> zgony_w_wyniku_covid_i_chorob_wspolistniejacych { get; set; }
        public Nullable<int> liczba_zlecen_poz { get; set; }
        public Nullable<int> liczba_ozdrowiencow { get; set; }
        public Nullable<int> liczba_osob_objetych_kwarantanna { get; set; }
        public Nullable<int> liczba_wykonanych_testow { get; set; }
        public Nullable<int> liczba_testow_z_wynikiem_pozytywnym { get; set; }
        public Nullable<int> liczba_testow_z_wynikiem_negatywnym { get; set; }
        public Nullable<int> liczba_pozostalych_testow { get; set; }
        public string teryt { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> stan_rekordu_na { get; set; }
    }
}
