#ifndef LAB6_BIGINT_HPP
#define LAB6_BIGINT_HPP

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <iomanip>
#include <cstdlib>

class TBigInt{
public:
    static const int base = 10;
    static const int digit = 1;

    TBigInt () = default;
    TBigInt (const int &);
    TBigInt (const std::string &);
    TBigInt (TBigInt &num, int j) {
        Data.resize(num.Data.size() - j);
        for (int i = 0; i < Data.size(); i++) {
            Data[i] = num.Data[i+j];
        }
    };

    void print() const;
    void setDigit(int, int);
    void DeleteZeros();
    static void Division(TBigInt &, TBigInt &, TBigInt &, TBigInt &);

    friend std::ostream& operator << (std::ostream&, const TBigInt&);
    friend TBigInt operator + (const TBigInt &, const TBigInt &);
    friend TBigInt operator - (const TBigInt &, const TBigInt &);
    friend TBigInt operator * (const TBigInt &, const TBigInt &);
    friend TBigInt operator / (const TBigInt &, const TBigInt &);
    friend TBigInt operator ^ (TBigInt &, TBigInt &);
    TBigInt & operator = (const TBigInt &);
    friend bool operator == (const TBigInt &, const TBigInt &);
    friend bool operator > (const TBigInt &, const TBigInt &);
    friend bool operator < (const TBigInt &, const TBigInt &);

private:
    std::vector<int> Data;

};

#endif //LAB6_BIGINT_HPP
