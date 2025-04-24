module.exports = {
    root: true,
    env: {
      node: true
    },
    extends: [
      'plugin:vue/vue3-recommended',
      'eslint:recommended',
      'prettier'   // <— this comes from eslint-config-prettier
    ],
    parser: 'vue-eslint-parser',
    parserOptions: {
      parser: '@babel/eslint-parser',
      requireConfigFile: false,
      babelOptions: {
        presets: ['@babel/preset-env']
      }
    },
    rules: {
      'comma-dangle': ['error', 'never']
    }
  }