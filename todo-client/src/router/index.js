import { createRouter, createWebHistory } from "vue-router";
import TodoList from "../views/TodoList.vue";
import AddItem from "@/views/AddItem.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: TodoList,
  },
  {
    path: "/add",
    name: "add",
    component: AddItem,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
