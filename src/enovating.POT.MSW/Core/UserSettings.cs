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

namespace enovating.POT.MSW.Core
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;

    /// <summary>
    ///     User settings.
    /// </summary>
    [DataContract]
    public class UserSettings
    {
        /// <summary>
        ///     Event triggered when successfully writing settings.
        /// </summary>
        public event EventHandler Wrote;

        /// <summary>
        ///     Gets the state.
        /// </summary>
        [IgnoreDataMember]
        public bool Ready => File.Exists(Target);

        /// <summary>
        ///     Gets the target file.
        /// </summary>
        [IgnoreDataMember]
        public string Target { get; private set; }

        /// <summary>
        ///     Gets or sets the template directory.
        /// </summary>
        [DataMember]
        public string TemplateDirectory { get; set; }

        /// <summary>
        ///     Initialize the user settings.
        /// </summary>
        /// <param name="target">The target file.</param>
        /// <returns>The user settings.</returns>
        public static UserSettings Initialize(string target)
        {
            if (!File.Exists(target))
            {
                return new UserSettings { Target = target };
            }

            using (var stream = new FileStream(target, FileMode.Open, FileAccess.Read))
            {
                var serializer = new DataContractJsonSerializer(typeof(UserSettings));
                var settings = (UserSettings) serializer.ReadObject(stream);

                settings.Target = target;
                settings.Validate();

                return settings;
            }
        }

        /// <summary>
        ///     Validates the current values.
        /// </summary>
        private void Validate()
        {
            if (string.IsNullOrEmpty(Target))
            {
                throw new ArgumentNullException(nameof(Target));
            }

            if (string.IsNullOrEmpty(TemplateDirectory))
            {
                throw new ArgumentNullException(nameof(TemplateDirectory));
            }
        }

        /// <summary>
        ///     Writes the settings.
        /// </summary>
        public void Write()
        {
            try
            {
                // valide settings values
                Validate();

                // write settings values
                using (var stream = new FileStream(Target, FileMode.Create, FileAccess.Write))
                {
                    var serializer = new DataContractJsonSerializer(typeof(UserSettings));
                    serializer.WriteObject(stream, this);
                }

                Wrote?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("failed to save settings", exception);
            }
        }
    }
}
