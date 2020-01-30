// -------------------------------------------------------------------------------------
// This file is part of 'Patent Office Tools' source code.
// 
// Patent Office Tools is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but without any warranty; without even the implied warranty of
// merchantability or fitness for a particular purpose. See the
// GNU Affero General Public License for more details.
// 
// Copyright 2019-2020 enovating SA <https://www.enovating.com/>
// -------------------------------------------------------------------------------------

namespace enovating.POT.MSW.Template.Writers
{
    using enovating.POT.MSW.Models;

    using Microsoft.Office.Interop.Word;

    /// <inheritdoc />
    public class FamilyWriter : IWriter<Patent>
    {
        /// <inheritdoc />
        public bool Can(string code, Patent value)
        {
            return code == "Family" && value.Family != null;
        }

        /// <inheritdoc />
        public void Write(string code, Patent value, Range target)
        {
            var table = target.Tables.Add(target, value.Family.Length, 4);

            for (var index = 0; index < table.Rows.Count; index++)
            {
                table.Cell(index + 1, 1).Range.Text = value.Family[index].PublicationNumber.ToString();
                table.Cell(index + 1, 2).Range.Text = value.Family[index].PublicationDate?.ToShortDateString();
                table.Cell(index + 1, 3).Range.Text = value.Family[index].ApplicationNumber.ToString();
                table.Cell(index + 1, 4).Range.Text = value.Family[index].ApplicationDate?.ToShortDateString();
            }
        }
    }
}
