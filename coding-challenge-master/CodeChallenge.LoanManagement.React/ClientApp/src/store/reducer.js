const loanActionType = 'First_Personal_Loan';
const initialState = { loans: [] };

export const reducer = (state, action) => {
  state = state || initialState;

    if (action.type === loanActionType) {
        return { ...state, loans: state.loans  };
  }

  return state;
};