<template>
  <div class="todo-item">
    <!-- Bind checked instead of v-model -->
    <input
      type="checkbox"
      :checked="todo.isCompleted"
      @change="toggleCompleted"
    />
    <span :class="{ done: todo.isCompleted }">{{ todo.title }}</span>
    <button @click="$emit('delete', todo.id)">✕</button>
  </div>
</template>

<script>
export default {
  name: 'TodoItem',
  props: {
    todo: { type: Object, required: true }
  },
  emits: ['update', 'delete'],
  methods: {
    toggleCompleted() {
      // Create a new object instead of mutating the prop
      const updated = {
        ...this.todo,
        isCompleted: !this.todo.isCompleted
      };
      this.$emit('update', updated);
    }
  }
};
</script>

<style scoped>
.done { text-decoration: line-through; }
.todo-item { display: flex; align-items: center; gap: 0.5rem; }
</style>