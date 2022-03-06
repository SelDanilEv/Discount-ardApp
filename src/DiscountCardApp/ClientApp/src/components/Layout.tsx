import * as React from "react";
import { Route, Routes } from "react-router-dom";
import LinearIndeterminate from "./ProgressBar/LinearIndeterminate";
import LayoutDefault from "./ContentLayout/LayoutDefault";
import HomeLayout from "./HomePage/HomeLayout";

const Layout = () => {

  return (
    <>
      <LayoutDefault>
        <LinearIndeterminate />
        <Routes>
          <Route path={"/"} element={<HomeLayout />} />
          {/* <Route path={"/Admin/ManageUsers"} element={<AdminPage />} />
          <Route path={"/ServiceRequests/Manage"} element={<RequestsPage />} />
          <Route path="/Account" element={<LoginAndRegistration />}>
            <Route path="Login" element={<Login />} />
            <Route path="Registration" element={<Registration />} />
            <Route path="ForgotPassword" element={<ForgotPassword />} />
            <Route path="ResetPassword" element={<ResetPassword />} />
          </Route>
          <Route path="/Account/Logout" element={<Logout />} /> */}
        </Routes>
      </LayoutDefault>
    </>
  );
};

export default Layout;
