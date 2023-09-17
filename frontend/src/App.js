import logo from './logo.svg';
import { Route, Routes } from 'react-router-dom'; //use Link to not a href, useMatch end:true for absolute, useResolvedPath (absolute path if /pricing, relative if pricing)
import Store from './Redux/Store/Store'
import { Provider } from 'react-redux';
import Sidebar from "./components/nav/Sidebar"
import Navbar from "./components/nav/Navbar";
import { useEffect } from 'react'
import { themeChange } from 'theme-change'
import Home from './pages/Home'
import ChatPage from './pages/ChatPage'

function App() {
  
  useEffect(() => {
    themeChange(false)
    // 👆 false parameter is required for react project
  }, [])
  
  return (
    <Provider store={Store}>
      <div className="flex">
        <div className="flex-none">
          <Sidebar/>
        </div>
        <div className={"flex flex-col flex-auto"}>
          <div className={"flex-none"}>
            <Navbar name={"Test friend"}/>
          </div>
          <div className="flex-auto px-5 pt-5 p-0 m-0">
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/chat" element={<ChatPage />} />
            </Routes>
          </div>
        </div>
      </div>
    </Provider>
  );
}

export default App;
