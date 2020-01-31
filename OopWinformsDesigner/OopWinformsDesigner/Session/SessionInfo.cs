namespace OopWinformsDesigner.Session {
    /// <summary>
    /// Definition of the session information about the current usage of the application.
    /// </summary>
    public class SessionInfo {
        private static SessionInfo instance = null;

        private SessionInfo() {
        }

        /// <summary>
        /// Gets the singleton instance of the current session.
        /// </summary>
        public static SessionInfo Instance {
            get {
                if (instance == null) {
                    instance = new SessionInfo();
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets or sets whether the solution/project has been loaded in this session.
        /// </summary>
        public bool IsSolutionOrProjectLoaded { get; set; } = false;
    }
}
