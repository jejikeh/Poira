import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import {FetchProduct} from "./components/FetchProduct";
import {FetchProductDetails} from "./components/FetchProductDetails";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/fetch-products',
    element: <FetchProduct/>
  },
  {
    path: '/fetch-product',
    element: <FetchProductDetails/>
  }
];

export default AppRoutes;
