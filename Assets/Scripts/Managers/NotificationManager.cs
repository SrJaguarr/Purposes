using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class NotificationManager : MonoBehaviour
{
#if UNITY_ANDROID

        private void Start(){

            var c = new AndroidNotificationChannel()
            {
                Id = "channel_id",
                Name = "Default Channel",
                Importance = Importance.High,
                Description = "Generic notifications",
            };
            AndroidNotificationCenter.RegisterNotificationChannel(c);


            var notification = new AndroidNotification();
            notification.Title = "TITULO";
            notification.Text = "TEXTO DE LA NOTIFICACION";
            notification.FireTime = System.DateTime.Now.AddMinutes(1);

            AndroidNotificationCenter.SendNotification(notification, "channel_id");


        }


#endif
}
