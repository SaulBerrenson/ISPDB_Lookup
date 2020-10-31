namespace ISPDB_Lookup.Xml
{
    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class clientConfig
    {

        private clientConfigEmailProvider emailProviderField;

        private decimal versionField;

        /// <remarks/>
        public clientConfigEmailProvider emailProvider
        {
            get
            {
                return this.emailProviderField;
            }
            set
            {
                this.emailProviderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class clientConfigEmailProvider
    {

        private string[] domainField;

        private string displayNameField;

        private string displayShortNameField;

        private clientConfigEmailProviderIncomingServer[] incomingServerField;

        private clientConfigEmailProviderOutgoingServer[] outgoingServerField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("domain")]
        public string[] domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }

        /// <remarks/>
        public string displayName
        {
            get
            {
                return this.displayNameField;
            }
            set
            {
                this.displayNameField = value;
            }
        }

        /// <remarks/>
        public string displayShortName
        {
            get
            {
                return this.displayShortNameField;
            }
            set
            {
                this.displayShortNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("incomingServer")]
        public clientConfigEmailProviderIncomingServer[] incomingServer
        {
            get
            {
                return this.incomingServerField;
            }
            set
            {
                this.incomingServerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("outgoingServer")]
        public clientConfigEmailProviderOutgoingServer[] outgoingServer
        {
            get
            {
                return this.outgoingServerField;
            }
            set
            {
                this.outgoingServerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class clientConfigEmailProviderIncomingServer
    {

        private string hostnameField;

        private ushort portField;

        private string socketTypeField;

        private string usernameField;

        private string authenticationField;

        private string typeField;

        /// <remarks/>
        public string hostname
        {
            get
            {
                return this.hostnameField;
            }
            set
            {
                this.hostnameField = value;
            }
        }

        /// <remarks/>
        public ushort port
        {
            get
            {
                return this.portField;
            }
            set
            {
                this.portField = value;
            }
        }

        /// <remarks/>
        public string socketType
        {
            get
            {
                return this.socketTypeField;
            }
            set
            {
                this.socketTypeField = value;
            }
        }

        /// <remarks/>
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        public string authentication
        {
            get
            {
                return this.authenticationField;
            }
            set
            {
                this.authenticationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class clientConfigEmailProviderOutgoingServer
    {

        private string hostnameField;

        private ushort portField;

        private string socketTypeField;

        private string usernameField;

        private string authenticationField;

        private string typeField;

        /// <remarks/>
        public string hostname
        {
            get
            {
                return this.hostnameField;
            }
            set
            {
                this.hostnameField = value;
            }
        }

        /// <remarks/>
        public ushort port
        {
            get
            {
                return this.portField;
            }
            set
            {
                this.portField = value;
            }
        }

        /// <remarks/>
        public string socketType
        {
            get
            {
                return this.socketTypeField;
            }
            set
            {
                this.socketTypeField = value;
            }
        }

        /// <remarks/>
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        public string authentication
        {
            get
            {
                return this.authenticationField;
            }
            set
            {
                this.authenticationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }


}