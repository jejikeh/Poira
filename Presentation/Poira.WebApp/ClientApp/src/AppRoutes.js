import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import {FetchProduct} from "./components/FetchProduct";
import {FetchProductDetails} from "./components/FetchProductDetails";
import {CreateProduct} from "./components/CreateProduct";

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
  },
  {
    path: '/create-product',
    element: <CreateProduct/>
  }
];

export default AppRoutes;
