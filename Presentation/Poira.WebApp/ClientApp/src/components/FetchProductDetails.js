import React, { Component } from 'react';

export class FetchProductDetails extends Component {
  static displayName = FetchProductDetails.name;

  constructor(props) {
    super(props);
    this.state = { id: "", detail: {}, loading: true };
    this.handleChange = this.handleChange.bind(this)
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
            <tr key={details.name}>
              <td>{details.name}</td>
              <td>{details.defaultQuantity}</td>
            </tr>
        </tbody>
      </table>
    );
  }
  
  handleChange(event) { 
    this.setState({id: event.target.value, detail: {}, loading: true});
  }
  
  render() {
    let contents = this.state.loading
      ? <input type="text" value={this.state.id} onChange={this.handleChange}/>
      : FetchProductDetails.renderDetailTable(this.state.detail);

    return (
      <div>
        <h1 id="tableLabel">Products</h1>
          <button className="btn btn-primary" onClick={ async () => {await this.populateProductsData(this.state.id)}}>Fetch</button>
          <p>This is working!</p>
        {contents}
      </div>
    );
  }

  async populateProductsData(id) {
    const response = await fetch('products/' + id);
    const data = await response.json();
    this.setState({ id: id, detail: data, loading: false });
  }
}
