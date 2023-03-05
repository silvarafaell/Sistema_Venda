import React from "react";
import { NavLink } from "react-router-dom";

const Product = () => {
  return (
    <div className="container">
      <div className="row">
        <div className="col-md-6 offset-md-3">
          <div className="text-center text-dark mt-5">Login</div>
          <div className="card my-5">

            <form className="card-body cardbody-color p-lg-5">

              <div className="text-center">
                <img src="/assets/user.png" className="img-fluid profile-image-pic img-thumbnail rounded-circle my-3"
                  width="200px" alt="profile" />
              </div>

              <div className="mb-3">
                <input type="text" className="form-control" id="Username" aria-describedby="emailHelp"
                  placeholder="User Name" />
              </div>
              <div className="mb-3">
                <input type="password" className="form-control" id="password" placeholder="password" />
              </div>
              <div className="text-center"><button type="submit" className="btn btn-primary px-5 mb-5 w-100">Login</button></div>
              <div id="emailHelp" className="form-text text-center mb-5 text-dark">Not Registered?
                <NavLink to="/Register" className="text-dark fw-bold"> 
                  Create an Account
                </NavLink>
              </div>
            </form>
          </div>

        </div>
      </div>
    </div>
  );
}

export default Product;