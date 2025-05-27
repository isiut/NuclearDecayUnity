using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementInfoUpdater : MonoBehaviour
{
    public TMP_Text aNumberLabel;
    public TMP_Text zNumberLabel;
    public TMP_Text elementAbbrLabel;

    private static List<string> elementAbbreviations = new List<string> {
    null,
    "H",
    "He",
    "Li",
    "Be",
    "B",
    "C",
    "N",
    "O",
    "F",
    "Ne",
    "Na",
    "Mg",
    "Al",
    "Si",
    "P",
    "S",
    "Cl",
    "Ar",
    "K",
    "Ca",
    "Sc",
    "Ti",
    "V",
    "Cr",
    "Mn",
    "Fe",
    "Co",
    "Ni",
    "Cu",
    "Zn",
    "Ga",
    "Ge",
    "As",
    "Se",
    "Br",
    "Kr",
    "Rb",
    "Sr",
    "Y",
    "Zr",
    "Nb",
    "Mo",
    "Tc",
    "Ru",
    "Rh",
    "Pd",
    "Ag",
    "Cd",
    "In",
    "Sn",
    "Sb",
    "Te",
    "I",
    "Xe",
    "Cs",
    "Ba",
    "La",
    "Ce",
    "Pr",
    "Nd",
    "Pm",
    "Sm",
    "Eu",
    "Gd",
    "Tb",
    "Dy",
    "Ho",
    "Er",
    "Tm",
    "Yb",
    "Lu",
    "Hf",
    "Ta",
    "W",
    "Re",
    "Os",
    "Ir",
    "Pt",
    "Au",
    "Hg",
    "Tl",
    "Pb",
    "Bi",
    "Po",
    "At",
    "Rn",
    "Fr",
    "Ra",
    "Ac",
    "Th",
    "Pa",
    "U",
    "Np",
    "Pu",
    "Am",
    "Cm",
    "Bk",
    "Cf",
    "Es",
    "Fm",
    "Md",
    "No",
    "Lr",
    "Rf",
    "Db",
    "Sg",
    "Bh",
    "Hs",
    "Mt",
    "Ds",
    "Rg",
    "Cn",
    "Nh",
    "Fl",
    "Mc",
    "Lv",
    "Ts",
    "Og",
  };

    private void Awake()
    {
        if (aNumberLabel == null)
            Debug.LogWarning("aNumberLabel is not assigned in the inspector!");
        if (zNumberLabel == null)
            Debug.LogWarning("zNumberLabel is not assigned in the inspector!");
        if (elementAbbrLabel == null)
            Debug.LogWarning("elementAbbrLabel is not assigned in the inspector!");
    }

    public void UpdateElementInfo()
    {
        int aNumber = GameData.aNumber;
        int zNumber = GameData.zNumber;
        string elementAbbreviation = elementAbbreviations[zNumber];

        // Only update if all labels are assigned
        if (aNumberLabel != null && zNumberLabel != null && elementAbbrLabel != null)
        {
            aNumberLabel.text = aNumber.ToString();
            zNumberLabel.text = zNumber.ToString();
            elementAbbrLabel.text = elementAbbreviation;
        }
    }
}
