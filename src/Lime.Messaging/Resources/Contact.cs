﻿using Lime.Protocol;
using System;
using System.Runtime.Serialization;

namespace Lime.Messaging.Resources
{
    /// <summary>
    /// Represents a contact information.
    /// </summary>
    [DataContract(Namespace = "http://limeprotocol.org/2014")]
    public class Contact : ContactDocument, IIdentity
    {
        public const string MIME_TYPE = "application/vnd.lime.contact+json";
        public static readonly MediaType MediaType = MediaType.Parse(MIME_TYPE);

        public const string NAME_KEY = "name";
        public const string IS_PENDING_KEY = "isPending";
        public const string SHARE_PRESENCE_KEY = "sharePresence";
        public const string SHARE_ACCOUNT_INFO_KEY = "shareAccountInfo";
        public const string PRIORITY_KEY = "priority";
        public const string GROUP_KEY = "group";
        public const string LAST_MESSAGE_DATE = "lastMessageDate";
        public const string LAST_UPDATE_DATE = "lastUpdateDate";
        public const string SUBSCRIPTION_STATUS_KEY = "subscriptionStatus";

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        public Contact()
            : base(MediaType)
        {
        }

        /// <summary>
        /// The name of the contact.
        /// This information is only visible by the roster owner.
        /// </summary>
        [DataMember(Name = NAME_KEY)]
        public string Name { get; set; }

        /// <summary>
        /// Determines if the contact is pending for acceptance by the roster owner.
        /// The default value is false.
        /// </summary>
        [DataMember(Name = IS_PENDING_KEY, EmitDefaultValue = false)]
        public bool? IsPending { get; set; }

        /// <summary>
        /// Indicates if the roster owner wants to share presence information with the contact.
        /// If true, the server provides a get delegation permission to the contact identity into the roster owner presence resource.
        /// The default value is true.
        /// </summary>
        [DataMember(Name = SHARE_PRESENCE_KEY, EmitDefaultValue = false)]
        public bool? SharePresence { get; set; }

        /// <summary>
        /// Indicates if the roster owner wants to share account information with the contact.
        /// If true, the server provides a get delegation permission to the contact identity into the roster owner account resource.
        /// The default value is true.
        /// </summary>
        [DataMember(Name = SHARE_ACCOUNT_INFO_KEY, EmitDefaultValue = false)]
        public bool? ShareAccountInfo { get; set; }

        /// <summary>
        /// Indicates the contact priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        [DataMember(Name = PRIORITY_KEY, EmitDefaultValue = false)]
        public int? Priority { get; set; }

        /// <summary>
        /// Indicates the contact group.
        /// </summary>
        [DataMember(Name = GROUP_KEY, EmitDefaultValue = false)]
        public string Group { get; set; }

        /// <summary>
        /// Indicates the last message received or sent date off the contact.
        /// </summary>
        [DataMember(Name = LAST_MESSAGE_DATE)]
        public DateTimeOffset? LastMessageDate { get; set; }

        /// <summary>
        /// Indicates the status from the subscription status of the account person to receive communication (Opt-in / Opt-out).
        /// </summary>
        [DataMember(Name = SUBSCRIPTION_STATUS_KEY)]
        public SubscriptionStatus? SubscriptionStatus { get; set; }

        /// <summary>
        /// Indicates the last change date in any contact field.
        /// </summary>
        [DataMember(Name = LAST_UPDATE_DATE)]
        public DateTime? LastUpdateDate { get; set; }

        [IgnoreDataMember]
        string IIdentity.Name => Identity?.Name;

        [IgnoreDataMember]
        string IIdentity.Domain => Identity?.Domain;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => Identity?.ToString() ?? string.Empty;

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return ToString().Equals(obj.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return Identity?.GetHashCode() ?? 0;
        }
    }

    /// <summary>
    /// Represents the subscription status of the account person to receive communication
    /// </summary>
    [DataContract(Namespace = "http://limeprotocol.org/2014")]
    public enum SubscriptionStatus
    {
        /// <summary>
        /// The Account is subscribed to receive communication
        /// </summary>
        [EnumMember(Value = "subscribed")]
        Subscribed,

        /// <summary>
        /// The Account is not subscribed to receive communication
        /// </summary>
        [EnumMember(Value = "not-subscribed")]
        NotSubscribed
    }
}