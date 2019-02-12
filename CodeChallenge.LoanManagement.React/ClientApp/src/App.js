import React from 'react';
import axios from 'axios';
import Loan from './components/Loan';
import './App.css';

class App extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            loans: []
        };
    }
    componentWillMount() {
        axios.get('http://localhost:8081/api/loan').then(response => this.setState({ loans: response.data }));
        console.log(this.state.loans);
    }
    render() {
        return (
            <div>
                <h3 className="borderBottom">Personal Loan TopUp or Apply</h3>
                <div className="loanTopUp row">
                    <div className="width70per">
                        <div className="information row borderRight">
                            <div className="col borderBottom fullWidth">
                                <p className="info-text">To apply for a topUp of an existing loan amount, please select the loan below, make note of the carry-over amount before proceeding.</p>
                                <p className="info-amt-text">
                                    <span>Carryover/payout Amount</span><b> $0</b>
                                </p>
                            </div>
                            <div className="col fullWidth borderBottom"><p>&nbsp;</p></div>
                        </div>
                    </div>
                    <div className="width30per btn-panel">
                        <div className="button row">
                            <div className="col fullWidth borderBottom"><button disabled>Apply for Increased Loan amount</button></div>
                            <div className="col fullWidth borderBottom"><button>Apply for new Personal amount</button></div>
                        </div>
                    </div>
                </div>
                <div className="row fullWidth">
                    <p className="personal-loan-info">You have 1 Personal Loan</p>
                    {
                        this.state.loans.map((loan, index) =>
                            <Loan
                                key={index}
                                id={loan.loanId}
                                name={loan.loanNumber}
                                description={loan.description}
                                balance={loan.balance}
                                interest={loan.balanceIncludeInterestof}
                                repayment={loan.earlyPaymentFee}
                                payout={loan.payoutAmount}
                            />)
                    }
                </div>
            </div>
        );
    }
}

export default App;

