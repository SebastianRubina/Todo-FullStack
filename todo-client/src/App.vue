<template>
  <h3><strong>Note: functionality to push new items to the database has been disabled to stop people from posting inappropriate items for everyone to see. Delete and Complete functionalities will not work with custom items either as the DELETE and PATCH requests won't find your item in the database.</strong></h3>
  <nav>
    <router-link to="/">Todo</router-link> |
    <router-link to="/add">Add Item</router-link>
  </nav>
  <div class="container">
    <router-view />
  </div>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}

.container {
  display: flex;
  justify-content: center;
}

p,
h1,
h2,
h3,
h4 {
  margin: 0;
  padding: 0;
}
</style>
