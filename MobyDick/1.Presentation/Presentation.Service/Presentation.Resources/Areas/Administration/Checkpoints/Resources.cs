using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace MBAdministration.Checkpoints {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Checkpoint Administration</summary>
        public static System.String CheckpointAdministration {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("CheckpointAdministration", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[CheckpointAdministration]";
                        }
               }
            }
            
        /// <summary>Checkpoint List</summary>
        public static System.String CheckpointList {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("CheckpointList", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[CheckpointList]";
                        }
               }
            }
            
        /// <summary>Code</summary>
        public static System.String CheckpointCode {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("CheckpointCode", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[CheckpointCode]";
                        }
               }
            }
            
        /// <summary>Description</summary>
        public static System.String CheckpointDescription {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("CheckpointDescription", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[CheckpointDescription]";
                        }
               }
            }
            
        /// <summary>Service IP</summary>
        public static System.String CheckpointIpService {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("CheckpointIpService", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[CheckpointIpService]";
                        }
               }
            }
            
        /// <summary>New Checkpoint</summary>
        public static System.String NewCheckpoint {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("NewCheckpoint", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[NewCheckpoint]";
                        }
               }
            }
            
        /// <summary>Checkpoint generated successfully</summary>
        public static System.String insertCheckpointMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("insertCheckpointMessage", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[insertCheckpointMessage]";
                        }
               }
            }
            
        /// <summary>Edit checkpoint</summary>
        public static System.String EditCheckpoint {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("EditCheckpoint", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[EditCheckpoint]";
                        }
               }
            }
            
        /// <summary>Could not modify the checkpoint</summary>
        public static System.String errorEditCheckpointMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("errorEditCheckpointMessage", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[errorEditCheckpointMessage]";
                        }
               }
            }
            
        /// <summary>The checkpoint was changed successfully</summary>
        public static System.String EditCheckpointMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("EditCheckpointMessage", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[EditCheckpointMessage]";
                        }
               }
            }
            
        /// <summary>The checkpoint was removed successfully</summary>
        public static System.String DeleteCheckpointMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("DeleteCheckpointMessage", CultureInfo.CurrentUICulture.Name,40);
                        }
                    catch (Exception)
                        {
                            return "[DeleteCheckpointMessage]";
                        }
               }
            }

        }        
}
