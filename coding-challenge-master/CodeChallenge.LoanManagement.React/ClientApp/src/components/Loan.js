import React from 'react';

class Loan extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            showDtl: false,
        };
        this.handleChange = this.handleChange.bind(this)
    }
    handleChange() {
        this.setState({
            showDtl: !this.state.showDtl
        });
    }
    render() {
        return (
            <div className="loan-table">
                <div className="table-header">
                    {this.props.id}. {this.props.description}
                </div>
                <div className="table-body">
                    <div className={this.state.showDtl ? "row borderBottom" : "row"}>
                        <p>Balance</p>
                        <p>${this.props.balance}</p>
                        <p><input type="checkbox" onChange={this.handleChange} /> Top Up</p>
                    </div>
                    {this.state.showDtl ?
                        <React.Fragment>
                            <div className="row">
                                <p>Balance include interest of</p>
                                <p>${this.props.interest}</p>
                                <p>&nbsp;</p>
                            </div>
                            <div className="row">
                                <p>Early repayment fee</p>
                                <p>${this.props.repayment}</p>
                                <p>&nbsp;</p>
                            </div>
                            <div className="row">
                                <p>Payout/ Carryover amount</p>
                                <p>${this.props.payout}</p>
                                <p>This amount will be carried over</p>
                            </div>
                        </React.Fragment> : null
                    }
                </div>
            </div>
        );
    }
}
export default Loan;