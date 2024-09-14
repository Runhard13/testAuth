import { createRouting, segment } from 'ts-routes'

const routes = createRouting({
  login: segment`/login`,
  welcome: segment`/welcome`,
  users: segment`/users`,
})

export { routes }
