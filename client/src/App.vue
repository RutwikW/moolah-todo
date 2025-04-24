<template>
  <div id="app">
    <h1>To-Do App</h1>
    <TodoList />
  </div>
</template>

<script>
import TodoList from './components/TodoList.vue';

export default {
  name: 'App',
  components: { TodoList }
};
</script>

<style>
#app { max-width: 600px; margin: 2rem auto; font-family: Arial, sans-serif; }
h1 { text-align: center; }
</style>