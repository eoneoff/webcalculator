﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Калькулятор.
        /// </summary>
        public static string Calculator {
            get {
                return ResourceManager.GetString("Calculator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Продолжить в оффлайн-режиме.
        /// </summary>
        public static string ContinueOffline {
            get {
                return ResourceManager.GetString("ContinueOffline", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to При сохранении истории произошла ошибка.
        /// </summary>
        public static string ErrorTookPlace {
            get {
                return ResourceManager.GetString("ErrorTookPlace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка сохранения истории.
        /// </summary>
        public static string HistorySaveError {
            get {
                return ResourceManager.GetString("HistorySaveError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Нет.
        /// </summary>
        public static string No {
            get {
                return ResourceManager.GetString("No", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Да.
        /// </summary>
        public static string Yes {
            get {
                return ResourceManager.GetString("Yes", resourceCulture);
            }
        }
    }
}
