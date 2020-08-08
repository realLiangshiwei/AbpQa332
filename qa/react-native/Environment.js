const ENV = {
  dev: {
    apiUrl: 'http://localhost:44339',
    oAuthConfig: {
      issuer: 'http://localhost:44339',
      clientId: 'qa_App',
      clientSecret: '1q2w3e*',
      scope: 'qa',
    },
    localization: {
      defaultResourceName: 'qa',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44339',
    oAuthConfig: {
      issuer: 'http://localhost:44339',
      clientId: 'qa_App',
      clientSecret: '1q2w3e*',
      scope: 'qa',
    },
    localization: {
      defaultResourceName: 'qa',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
