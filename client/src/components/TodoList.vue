<!-- gist: testing git change detection -->
<template>
  <div class="todo-container">
    <!-- Header with provider toggle and search -->
    <div class="header">
      <ProviderSelector
        :modelValue="provider"
        @change="changeProvider"
      />
      <SearchBar @search="searchTodos" />
    </div>

    <!-- Add form -->
    <div class="new-form">
      <TodoForm @add="addTodo" />
    </div>

    <!-- Animated list of cards -->
    <transition-group name="list" tag="ul" class="todo-list">
      <li
        v-for="todo in todos"
        :key="todo.id"
        class="todo-card"
      >
        <TodoItem
          :todo="todo"
          :provider="provider"
          @update="updateTodo"
          @delete="deleteTodo"
        />
      </li>
    </transition-group>
  </div>
</template>

<script>
import axios from 'axios';
import ProviderSelector from './ProviderSelector.vue';
import SearchBar from './SearchBar.vue';
import TodoForm from './TodoForm.vue';
import TodoItem from './TodoItem.vue';

export default {
  name: 'TodoList',
  components: { ProviderSelector, SearchBar, TodoForm, TodoItem },
  data: () => ({
    todos: [],
    provider: '',
    searchQuery: ''
  }),
  watch: {
    provider() { this.fetchTodos() },
    searchQuery() { this.fetchTodos() }
  },
  mounted() {
    this.fetchTodos();
  },
  methods: {
    async fetchTodos() {
      const params = {};
      if (this.provider) params.provider = this.provider;
      if (this.searchQuery) params.search = this.searchQuery;
      const res = await axios.get('/api/ToDos', { params });
      this.todos = res.data;
    },
    changeProvider(val) { this.provider = val },
    searchTodos(query) { this.searchQuery = query },
    addTodo(todo) {
      axios.post('/api/ToDos', todo, { params: { provider: this.provider } })
           .then(() => this.fetchTodos());
    },
    updateTodo(todo) {
      axios.put(`/api/ToDos/${todo.id}`, todo, { params: { provider: this.provider } })
           .then(() => this.fetchTodos());
    },
    deleteTodo(id) {
      axios.delete(`/api/ToDos/${id}`, { params: { provider: this.provider } })
           .then(() => this.fetchTodos());
    }
  }
};
</script>

<style scoped>
.todo-container {
  max-width: 600px;
  margin: 2rem auto;
  padding: 0 1rem;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, sans-serif;
}

.header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1rem;
}

.new-form {
  margin-bottom: 1rem;
}

.todo-list {
  list-style: none;
  padding: 0;
  margin: 0;
}

.todo-card {
  background: #fff;
  margin-bottom: 0.75rem;
  padding: 1rem;
  border-radius: 8px;
  box-shadow: 0 2px 6px rgba(0,0,0,0.1);
  transition: all 0.3s ease;
}

/* transition-group animations */
.list-enter-active, .list-leave-active {
  transition: all 0.3s ease;
}
.list-enter-from, .list-leave-to {
  opacity: 0;
  transform: translateY(-10px);
}
</style>