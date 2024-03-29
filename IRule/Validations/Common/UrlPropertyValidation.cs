﻿using Microservice.Framework.Common;
using XRule.Notifications;

namespace XRule.Validations.Common
{
    public abstract class UrlPropertyValidation<T> 
        : Validation<T> where T : class
    {
        #region Virtual Methods

        protected override Task<Notification> OnValidate(CancellationToken cancellationToken)
        {
            var notification = Notification.CreateEmpty();

            var propertyValue = PropertyValue.AsString();

            if (propertyValue.IsNotNullOrEmpty())
            {
                Uri uri = null;

                try
                {
                    uri = new Uri(propertyValue);
                }
                catch (UriFormatException)
                {
                }

                if (uri.IsNull() || uri.Scheme.IsNullOrEmpty() || uri.Authority.IsNullOrEmpty())
                {
                    notification.AddMessage(OnCreateMessage());
                }
            }

            return Task.FromResult(notification);
        }

        protected virtual Message OnCreateMessage()
        {
            return CreateMessage("{0} is an invalid url format", DisplayName);
        }

        #endregion
    }
}
