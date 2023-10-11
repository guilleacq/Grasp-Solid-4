//-------------------------------------------------------------------------------
// <copyright file="Equipment.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID
{
    public class Equipment : CatalogItem
    {
        public Equipment(string description, double hourlyCost) : base(description, hourlyCost)
        {
        }
    }
}