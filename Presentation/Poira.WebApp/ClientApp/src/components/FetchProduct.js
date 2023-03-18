import React, { Component } from 'react';

export class FetchProduct extends Component {
  static displayName = FetchProduct.name;

  constructor(props) {
    super(props);
    this.state = { detail: [], loading: true };
  }

  componentDidMount() {
        this.populateProductsData();
  }
  
  static renderDetailTable(details) {
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Default Quantity</th>
          </tr>
        </thead>
        <tbody>
        {details.map(forecast =>
            <tr key={forecast.name}>
              <td>{forecast.name}</td>
              <td>{forecast.defaultQuantity}</td>
            </tr>
        )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchProduct.renderDetailTable(this.state.detail);

    return (
      <div>
        <h1 id="tableLabel">Products</h1>
        <p>This is working!</p>
        {contents}
      </div>
    );
  }

  async populateProductsData() {
    const response = await fetch('products');
    const data = await response.json();
    this.setState({ detail: data, loading: false });
  }
}
